    private void ACallback( ISelenium selenium )
    {
        selenium.Start();
        selenium.Open(domainToBeTested);
        selenium.Click("link=Email");
        Assert.IsTrue(selenium.IsElementPresent("//div[@id='tabs-2']/p/a/strong"));
        selenium.Click("link=Address");
        Assert.IsTrue(selenium.IsElementPresent("//div[@id='tabs-3']/p/strong"));
        selenium.Click("link=Telephone");
        Assert.IsTrue(selenium.IsElementPresent("//div[@id='tabs-1']/ul/li/strong"));
    }
