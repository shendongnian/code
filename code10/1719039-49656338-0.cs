    //remove this line IWebElement popOver = Driver.FindElement(By.Id("popOver"));
    Driver.SwitchTo().DefaultContent();
    IWebElement popOverFrame = Driver.FindElement(By.Id("popOverFrame"))
    Driver.SwitchTo().Frame(popOverFrame);
    //remove this line IWebElement table1 = popOverFrame.FindElement(By.XPath("//*[@id='form1']/table"));
    IWebElement Table2 = Driver.FindElement(By.XPath("//*[@id='tblReport']"));
    Table2.FindElement(By.Id("contentPlaceholder_btnPrint")).Click();
