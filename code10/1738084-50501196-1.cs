    WebBrowser = new ChromeDriver();
    IWebElement inputEMail, inputPassword, loginButton;
    WebBrowser.Navigate().GoToUrl(
        "http://www.yourOAuthProvider.com?client_id=ABCDE&AnyAdditionalParameters");
    Thread.Sleep(1 * 3000);
    this.Log(this.WebBrowser.Title);
    inputEMail = this.WebBrowser.FindElement(By.Name("email"));
    inputEMail.SendKeys("user@example.com");
    inputPassword = this.WebBrowser.FindElement(By.Name("password"));
    inputPassword.SendKeys("PasswordAtExampleDotCom");
    loginButton = this.WebBrowser.FindElement(By.ClassName("submit"));
    loginButton.Click();
    Thread.Sleep(1 * 3000);
    this.Log(this.WebBrowser.Url);
    WebBrowser.Close();
