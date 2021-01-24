    public void Click(ByControlWithName Control)
    {
        WaitForControlClickable(Control.Control);
        TestInitiator.driver.FindElement(Control.Control).Click();
        reporter.LogInfo("User clicked on: " + Control.ControlName);
    }
