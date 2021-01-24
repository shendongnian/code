    public static decimal ConvertToNumber(string str)
    {
        return decimal.Parse(str, NumberStyles.Currency);
    }
    [Test]
    public void TestAccountValue()
    {
         
        Assert.IsTrue(ConvertToNumber(driver.FindElement(By.XPath("//div[contains(@class, 'w-create-account']/h2")).Text) > 0, "Account value is not greater than zero.");
        
    }
