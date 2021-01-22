    public static CookieContainer GetCookieContainer(this System.Web.HttpRequest SourceHttpRequest, System.Net.HttpWebRequest TargetHttpWebRequest)
        {
            System.Web.HttpCookieCollection sourceCookies = SourceHttpRequest.Cookies;
            if (sourceCookies.Count == 0)
                return null;
            else
            {
                CookieContainer cookieContainer = new CookieContainer();
                for (int i = 0; i < sourceCookies.Count; i++)                
                {
                    System.Web.HttpCookie cSource = sourceCookies[i];
                    Cookie cookieTarget = new Cookie() { Domain = TargetHttpWebRequest.RequestUri.Host, 
                                                         Name = cSource.Name, 
                                                         Path = cSource.Path, 
                                                         Secure = cSource.Secure, 
                                                         Value = cSource.Value };
                    cookieContainer.Add(cookieTarget);
                }
                return cookieContainer;
            }
        }
