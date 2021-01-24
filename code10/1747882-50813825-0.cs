	//SwitchTo mytestTopsubframe
	new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Name("mytestTopsubframe")));
	//SwitchTo mytestsubframe
	new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Name("mytestsubframe")));
	//Locate the desired element
	new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@class='clslogin' and @href='linkref']"))).Click();
