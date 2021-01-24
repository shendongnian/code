    public CashLoadingHo ClickSave()
    {
        wrapper.Click(btnSave)
               .AcceptAlert();
        return this;
    }
    public CashLoadingHo AlertEnterCarrierId(string id)
    {
        WaitForAlert(); //Explained below
        driver.SwitchTo().Alert().SendKeys(id);
        driver.SwitchTo().Alert().Accept();
        //Now, swap back to your main window.
        driver.SwitchTo().DefaultContent();
        return this;
    }
    public CashLoadingHo AlertEnterAmount(string amount)
    {
        WaitForAlert(); //Explained below
        driver.SwitchTo().Alert().SendKeys(amount);
        driver.SwitchTo().Alert().Accept();
        //Now, swap back to your main window.
        driver.SwitchTo().DefaultContent();
        return this;
    }
