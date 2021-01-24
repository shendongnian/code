    if (HttpContext.Request.Cookies[".MyCookie"] != null)
    {
        var siteCookies = HttpContext.Request.Cookies.Where(c => c.Key.StartsWith(".MyCookie"));
        foreach (var cookie in siteCookies)
        {
            Response.Cookies.Delete(cookie.Key);
        }
    }
