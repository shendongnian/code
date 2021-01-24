    namespace Test
    {
        public class JSONUtils : MonoBehaviour
        {
            public delegate void ReqCallback(bool isNetworkError, bool isHttpError, string error, string body);
    
            public void GetJSON(string uri, ReqCallback callback)
            {
                // How to return a string from RequestJSON?
                StartCoroutine(RequestJSON(uri, callback));
            }
    
            private IEnumerator RequestJSON(string url, ReqCallback callback)
            {
                using (UnityWebRequest www = UnityWebRequest.Get(url))
                {
                    //Send request
                    yield return www.SendWebRequest();
                    //Return result
                    callback(www.isNetworkError, www.isHttpError, www.error, www.downloadHandler.text);
                }
            }
        }
    }
