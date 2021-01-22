        private void setSessionCookie() {
            HttpCookie ck = new HttpCookie(XConstants.X_SESSION_COOKIE_KEY) {
                Expires = DateTime.Now.AddMinutes(_sessionInfo.SessionTimeoutMinutes)
            };
            DateTime now = DateTime.UtcNow;
            _sessionInfo.SessionLastValidatedAt = now;
            ck.HttpOnly = true; // server-only cookie
            ck["LastCheck"] = now.ToString(XConstants.XDATEFORMAT);
            ck["Content"] = new Cipher().Encrypt(Serializer.Serialize(_sessionInfo).OuterXml,
                ConfigurationManager.AppSettings[XConstants.X_APPKEY_KEY]);
            System.Web.HttpContext.Current.Response.Cookies.Add(ck);
        }
