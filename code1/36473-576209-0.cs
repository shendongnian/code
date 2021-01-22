    public void WriteCookie(string name, string value)
    {
        var cookie = new HttpCookie(name, value);
        HttpContext.Current.Response.Cookies.Set(cookie);
    }
    public string ReadCookie(string name)
    {
        if (HttpContext.Current.Response.Cookies.AllKeys.Contains(name))
        {
            var cookie = HttpContext.Current.Response.Cookies[name];
            return cookie.Value;
        }
    
        if (HttpContext.Current.Request.Cookies.AllKeys.Contains(name))
        {
            var cookie = HttpContext.Current.Request.Cookies[name];
            return cookie.Value;
        }
    
        return null;
    }
