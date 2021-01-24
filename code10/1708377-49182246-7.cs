    [Given(@"I have the following items in the specified (.*):")]
    public void InitFromConfiguration(string browser, MenuItem[] menuItems)
    {
        ScenarioContext.Current.Set(browser, nameof(browser));
        ScenarioContext.Current.Set(menuItems, nameof(menuItems));
    }
