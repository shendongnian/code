    public HttpCookie Get(string name)
    {
        HttpCookie cookie = (HttpCookie) base.BaseGet(name);
        if ((cookie == null) && (this._response != null))
        {
            cookie = new HttpCookie(name);
            this.AddCookie(cookie, true);
            this._response.OnCookieAdd(cookie);
        }
        return cookie;
    }
