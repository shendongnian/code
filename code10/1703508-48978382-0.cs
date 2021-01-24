    public static T PostCast<T>(string url, Dictionary<string, string> data)
    {
        using (HttpClient httpClient = new HttpClient())
        {
            var response = httpClient.PostAsync(url, new FormUrlEncodedContent(data)).Result;
            return response.Content.ReadAsAsync<T>().Result;
        }
    }
