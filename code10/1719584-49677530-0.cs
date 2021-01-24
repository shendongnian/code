    public void WaitForElementExplicitly(int WaitInMilliSeconds = 3000, By Selector = null)
    {
      WebDriverWait wait = new WebDriverWait(CommonTestObjects.IWebDriver, TimeSpan.FromSeconds(WaitInMilliSeconds / 1000));
      IWebElement myDynamicElement = wait.Until<IWebElement>((d) =>
      {
        return d.FindElement(Selector);
      });
    }
