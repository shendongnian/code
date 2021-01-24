    private By actionDialogLocator = By.Id("actionDialog");
    private By cancelButtonLocator = By.Id("cancel");
    private By saveButtonLocator = By.Id("save");
    public void Cancel()
    {
        Driver.FindElement(cancelButtonLocator).Click();
        WaitForDialogToClose();
    }
    public void Save()
    {
        Driver.FindElement(saveButtonLocator).Click();
        WaitForDialogToClose();
    }
    private void WaitForDialogToClose()
    {
        new WebDriverWait(Driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.InvisibilityOfElementLocated(actionDialogLocator));
    }
