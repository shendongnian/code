       WebClientEx myWebClient = new WebClientEx(new CookieContainer());
       CookieCollection cc = new CookieCollection();
       foreach (OpenQA.Selenium.Cookie cook in driver.Manage().Cookies.AllCookies)
       {
            System.Net.Cookie cookie = new System.Net.Cookie();
            cookie.Name = cook.Name;
            cookie.Value = cook.Value;
            cookie.Domain = cook.Domain;
            cc.Add(cookie);
       }
       myWebClient.CookieContainer.Add(cc);
