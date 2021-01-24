        public string GetCookie(string key)
        {
            return Request.Cookies[key];
        }
        public void SetCookie(string key, string value, double? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(1);
            Response.Cookies.Append(key, value, option);
        }
        public void RemoveCookie(string key)
        {
            Response.Cookies.Delete(key);
        }
