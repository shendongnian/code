    protected void Application_BeginRequest(object sender, EventArgs e)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["NAMEOFCOOKIE"];
                if (cookie != null && cookie.Value != null)
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookie.Value);
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookie.Value);
                }
                else
                {
                   // FIND IN DB YOUR USER'S LANGUAGE AND SET IT 
                            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("YOUR USERS'S DB VALUE");
                            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("YOUR USERS'S DB VALUE");
                            HttpCookie cookieNew = new HttpCookie("NAMEOFCOOKIE");
                            cookieNew.Value = "YOUR USERS'S DB VALUE";
                            Response.Cookies.Add(cookieNew);
                        }
                    }
                }
            }
