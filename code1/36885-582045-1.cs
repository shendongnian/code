    public HttpCookieCollection Cookies
    {
        get
        {
            if (this._cookies == null)
            {
                this._cookies = new HttpCookieCollection(this, false);
            }
            return this._cookies;
        }
    }
