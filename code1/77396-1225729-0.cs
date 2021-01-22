        public static string SessionKey
        {
            get { return GetFacebookCookie("session_key"); }
        }
        private static string GetFacebookCookie(string propertyName)
        {
            var fullName = ApiKey + "_" + propertyName;
            if (HttpContext.Current == null || HttpContext.Current.Request.Cookies[fullName] == null)
                return null;
            return HttpContext.Current.Request != null ? HttpContext.Current.Request.Cookies[fullName].Value : null;
        }
