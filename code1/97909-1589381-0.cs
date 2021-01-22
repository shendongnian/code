    private string CurrentDomain()
    {
        string currDomain = Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host;
        if (Request.Url.Port != 80 && Request.Url.Port != 443)
            currDomain += (":" + Request.Url.Port);
        return currDomain;
    }
