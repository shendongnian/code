    public static void ClearCookies()
                {
                    HttpCookie cookie = new HttpCookie("test");
        
                    cookie.Name = "test";
                    cookie.Value = string.Empty;
                    cookie.Expires = DateTime.Now.AddDays(-1);
        
                    if (HttpContext.Current.Response.Cookies.AllKeys.Contains("test"))
                    {
                        HttpContext.Current.Response.Cookies.Set(cookie);
                    }
                    else
                    {
                        HttpContext.Current.Response.Cookies.Add(cookie);
                    }
                }
