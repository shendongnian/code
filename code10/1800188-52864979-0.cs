    async Task<bool> GetHttpAsyncStatus()
    {
        var request = HttpWebRequest.Create(url);
        request.Method = "GET";
        request.Timeout = 1500;
        using (HttpWebResponse reponse = await request.GetResponseAsync() as HttpWebResponse)
        {
            if (reponse.StatusCode == HttpStatusCode.OK)
            {
                // no UI Action, just return the result
                reponse.Close();
                return true;
            }
            return false;
         }
    }
