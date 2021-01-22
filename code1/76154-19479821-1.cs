    public string Upload(string url, NameValueCollection requestParameters, MemoryStream file)
            {
    
                var client = new HttpClient();
                var content = new MultipartFormDataContent();
        
                content.Add(new StreamContent(file));
                System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>> b = new List<KeyValuePair<string, string>>();
                b.Add(a);
                var addMe = new FormUrlEncodedContent(b);
    
                content.Add(addMe);
                var result = client.PostAsync(url, content);
                return result.Result.ToString();
            }
