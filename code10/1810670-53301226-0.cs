    webDriver.Navigate().GoToUrl(url);
            try
            {
                await Task.Delay(1000);
                Logger.LogGenericText("Trying to Removed all Nicknames Cache...");
                webDriverwait.Until(d => d.FindElement(By.ClassName("namehistory_link"))).Click();
                await Task.Delay(2000);
                webDriverwait.Until(d => d.FindElement(By.XPath("//*[@id='NamePopupClearAliases']"))).Click();
                await Task.Delay(2000);
                webDriver.SwitchTo().ActiveElement().FindElement(By.XPath("/html/body/div[3]/div[2]/div/div[2]/div[1]/span")).Click();
                Logger.LogGenericText("All Nickname List Cleared.");
            }
            catch (Exception ex)
            {
                Logger.LogGenericText(ex.ToString());
                return;
            }
