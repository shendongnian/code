    public static void MaximiseNWKBrowser(IWebDriver d)
            {
                var body = UICommon.GetElement(By.TagName("body"), d);
                body.Click();
                string alt = "%";
                string space = " ";
                string down = "{DOWN}";
                string enter = "{ENTER}";
                SendKeys.SendWait(alt + space);
                for(var i = 1; i <= 6; i++)
                {
                    SendKeys.SendWait(down);
                }
                SendKeys.SendWait(enter);            
            }
