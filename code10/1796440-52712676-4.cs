    public class API
    {
    
        public IEnumerator Login(string email, string psw, Action<string> token)
        {
            string URL = "https://####.azurewebsites.net/api/login";
            WWWForm form = new WWWForm();
            form.AddField("email", email);
            form.AddField("password", psw);
    
            var download = UnityWebRequest.Post(URL, form);
    
            // Wait until the download is done
            yield return download.SendWebRequest();
    
            if (download.isNetworkError || download.isHttpError)
            {
                Debug.Log("Error downloading: " + download.error);
            }
            else
            {
                JsonData data = JsonMapper.ToObject(download.downloadHandler.text);
                string tokenResult = (string)data["success"]["token"];
                Debug.Log(tokenResult);
                if (token != null)
                    token(tokenResult);
            }
        }
    }
