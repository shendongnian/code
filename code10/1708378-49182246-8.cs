    [When(@"I test the (.*) with the given (.*)")]
    public void InitFromConfiguration(string browserKey, string menuItemsKey)
    {
        var browser = ScenarioContext.Current.Get<string>(browserKey);
        var menuItems = ScenarioContext.Current.Get<MenuItem[]>(menuItemsKey);
        // TODO: in DoTest you can collect and save the possible errors in the context
        foreach (MenuItem mi in menuItems)
            DoTest(browser, mi);
    }
