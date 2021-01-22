    private IWebElement GetElementInIFrame(By selector)
    {
      try
      {    
        var iFrameElement = Driver.FindElementByTagName("iFrame");
        var driver = Driver.SwitchTo().Frame(this.iFrameElement);
        return driver.FindElement(selector);
      }
      finally
      {
        // don't forget to switch back to the DefaultContent
        Driver.SwitchTo().DefaultContent();
      }
    }
