       HttpCookie cookie = new HttpCookie(FormsCookieName, str);
        cookie.HttpOnly = true;
        cookie.Path = _FormsCookiePath;
        cookie.Expires = new DateTime(1999, 10, 12);
        cookie.Secure = _RequireSSL;
        if (_CookieDomain != null)
        {
            cookie.Domain = _CookieDomain;
        }
        current.Response.Cookies.RemoveCookie(FormsCookieName);
        current.Response.Cookies.Add(cookie);
