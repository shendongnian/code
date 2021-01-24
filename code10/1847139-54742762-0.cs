     public static bool SetCookie(string cookieName, object value, int expires)
        {
            try
            {
                HttpCookie cookie_clc = new HttpCookie(cookieName, value.ToString());
                cookie_clc.Expires = DateTime.Now.AddMinutes(expires);
                HttpContext.Current.Response.Cookies.Add(cookie_clc);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
         
        }
