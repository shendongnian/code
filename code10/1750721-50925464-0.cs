    //To get/set cookies
    using (var protocolFilter = new HttpBaseProtocolFilter())
    {
        //get CookieManager instance
        var cookieManager = protocolFilter.CookieManager;
        //get cookies
        var cookies = cookieManager.GetCookies(uri);
        foreach (var cookie in cookies)
        {
            Debug.Write(cookie.Value);
        }
        //you can also SetCookie
        //cookieManager.SetCookie(MyCookie);
    }
