using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class item_manager : MonoBehaviour
{
    [Header("道具圖片")]
    public Sprite[] item_image;

    [Header("要修改的道具圖片")]
    public Image imgItem;

    [Header("跑圖速度"), Range(0f, 1f)]
    public float speed = 0.5f;

    [Header("跑的回數")]
    public int count_time = 1;

    [Header("抽牌聲音")]
    public AudioClip Draw_AC;
    public AudioClip finalitme_AC;
    private AudioSource Draw_Aud;

    [Header("按鈕")]
    public Button startdraw;

    private void Start()
    {
        Draw_Aud = GetComponent<AudioSource>();
    }

    public void DrawItem()
    {
        StartCoroutine(RandomDrawItem());
    }
    /// <summary>
    /// 隨機抽取道具
    /// </summary>
    /// <returns></returns>
    public IEnumerator RandomDrawItem()
    {
        for (int j = 0; j < count_time; j++)
        {
            for (int i = 0; i < item_image.Length; i++)
            {
                startdraw.enabled = false;
                int random_num = Random.Range(0, item_image.Length);
                imgItem.sprite = item_image[random_num];
                Draw_Aud.PlayOneShot(Draw_AC, 0.5f);
                //print(random_num);
                yield return new WaitForSeconds(speed);
            }
        }
        yield return new WaitForSeconds(speed);
        Draw_Aud.PlayOneShot(finalitme_AC, 0.5f);
        startdraw.enabled = true;
    }


}
