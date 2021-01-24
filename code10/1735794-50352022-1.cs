    public Login ClickGetStatus()
    {
        //IWebElement btnGetStatus = driver.FindElement(By.XPath("//*
        [contains(@id,'GetStatus')]"));
        do
        {
        buttonName_GetStatus[0] = "abc";
        Thread.Sleep(3000);
        
        var elements = wrapper.IsElementDisplayed(
                driver.FindElements(By.XPath("//*[contains(@id,'GetStatus')]")));
        var is_displayed = elements.Count > 0;
        //bool IsElementDisplayed = driver.FindElement(By.XPath("//*[contains(@id,'GetStatus')]")).Displayed;
        if (is_displayed)
        {
            //wrapper.Click(btnExecute);
            string getnameofbutton1 = 
                driver.FindElement(
                    By.XPath("//*[contains(@id,'GetStatus')]")).GetAttribute("id");
            Console.WriteLine("Name of the button is : " + getnameofbutton1);
            buttonName_GetStatus = getnameofbutton1.Split('_');
            driver.FindElement(
                By.XPath("//*[contains(@id,'GetStatus')]")).Click();
        }
        else
        {
            Console.WriteLine("Element is not displayed");
        }
    }
    while (buttonName_GetStatus[0] != "ViewResult");
    return this;
    }
