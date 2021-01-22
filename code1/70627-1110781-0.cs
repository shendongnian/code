    private static string GetRealUrl(string url)
    {
        WebRequest request = WebRequest.Create(url);
        request.Method = WebRequestMethods.Http.Head;
        WebResponse response = request.GetResponse();
        return response.ResponseUri.ToString();
    }
