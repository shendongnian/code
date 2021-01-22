    public void ReloadPage()
    {
        UrlBuilder url = new UrlBuilder(Context, Request.Path);
        foreach (string queryParam in Request.QueryString.AllKeys)
        {
            string queryParamValue = Request.QueryString[queryParam];
            url.AddQueryItem(queryParam, queryParamValue);
        }
        Response.Redirect( url.ToString(), true);
    }
