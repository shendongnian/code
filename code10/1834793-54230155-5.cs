    using UnityEngine;
    using System.Collections;
    using UnityEngine.Networking;
 
    public class MyBehaviour : MonoBehaviour 
    {
        void Start() 
        {
            StartCoroutine(GetTexture());
        }
 
        IEnumerator GetTexture() 
        {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture("http://www.my-server.com/image.png");
            yield return www.SendWebRequest();
            if(www.isNetworkError || www.isHttpError) 
            {
                Debug.Log(www.error);
            }
            else 
            {
                Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            }
        }
    }
