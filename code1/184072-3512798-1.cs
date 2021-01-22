    private void setSessionCookie() {
        HttpCookie ck = new HttpCookie(GCConstants.GC_SESSION_COOKIE_KEY) {
            Expires = DateTime.Now.AddMinutes(_sessionInfo.SessionTimeoutMinutes)
        };
        DateTime now = DateTime.UtcNow;
        _sessionInfo.SessionLastValidatedAt = now;
        ck.HttpOnly = true; // server-only cookie
        ck["LastCheck"] = now.ToString(GCConstants.GCDATEFORMAT);
        ck["Content"] = new Cipher().DESEncrypt(Serializer.Serialize(_sessionInfo).OuterXml,
            ConfigurationManager.AppSettings[GCConstants.GC_APPKEY_KEY]);
        System.Web.HttpContext.Current.Response.Cookies.Add(ck);
    }
