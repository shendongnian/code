    public CashLoadingHo WaitForAlert()
    {
        //Initialize your wait object.
        WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.AlertIsPresent());
        return this;
    }
