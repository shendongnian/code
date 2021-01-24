	IwebDriver  _webdriver = new ChromeDriver();
	_webdriver.Navigate().GoToUrl("https://www.youtube.com/");
	new WebDriverWait(_webdriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input#search"))).SendKeys("Perfect");
	_webdriver.FindElement(By.CssSelector("button.style-scope.ytd-searchbox>yt-icon")).Click();
	IList<IWebElement> contents = new WebDriverWait(_webdriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("h3.title-and-badge.style-scope.ytd-video-renderer a")));
	foreach (IWebElement content in contents)
		if(content.GetAttribute("innerHTML").Contains("Lyrics"))
		{
			content.Click();
			break; 
		}
