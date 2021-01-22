    public void WriteCookie(string strCookieName, string strCookieValue)
        {
            var hcCookie = new HttpCookie(strCookieName, strCookieValue);
            HttpContext.Current.Response.Cookies.Set(hcCookie);
        }
    
    
        public string ReadCookie(string strCookieName)
        {    
            foreach (string strCookie in HttpContext.Current.Response.Cookies.AllKeys)
            {
                if (strCookie == strCookieName)
                {
                    return HttpContext.Current.Response.Cookies[strCookie].Value;
                }
            }         
    
            foreach (string strCookie in HttpContext.Current.Request.Cookies.AllKeys)
            {
                if (strCookie == strCookieName)
                {
                    return HttpContext.Current.Request.Cookies[strCookie].Value;
                }
            }
            return null;
        }
