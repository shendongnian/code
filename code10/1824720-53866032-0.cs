    public bool TryConnect()
    {
        WebRequest request = WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        return response.StatusCode == HttpStatusCode.OK;
    }
