    IwebDriver  _webdriver = new ChromeDriver();
    _webdriver.Navigate().GoToUrl("https://www.youtube.com/");
    var element = wait.Until(x => x.FindElement(By.Id("search")));
    element.SendKeys("Perfect");
    var element = wait.Until(x => x.FindElement(By.CssSelector("#search-icon- 
    legacy>yt-icon")));
    element.Click();
    var content = wait.Until(x => x.FindElement(By.Id("contents")));
    var songHREF = content.FindElements(By.CssSelector("#video-title"));
    var wait2 = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
    wait2.Until(ExpectedConditions.ElementIsClickable(songHREF[2]));
    songHREF[2].Click();
