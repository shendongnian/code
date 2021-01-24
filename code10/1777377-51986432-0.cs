    private IEnumerator Upload(string base64Image, Action<ImgurUploadResponse> OnUploadCompleted){
            using (WebClient wclient = new WebClient()){
                wclient.Headers.Add("Authorization", "Client-ID " + _clientId);
                NameValueCollection parameters = new NameValueCollection(){
                    { "image", base64Image }
                };
    
                byte[] response = wclient.UploadValues(_baseUploadUrl, parameters);
                string json = Encoding.UTF8.GetString(response);
    
                Debug.Log("completed "+json);
                OnUploadCompleted(JsonUtility.FromJson<ImgurUploadResponse>(json));
            }
    }
