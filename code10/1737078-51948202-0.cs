    public static List<string> GetFieldsName()
    {
        List<string> expected = new List<string>();
        IList<IWebElement> labels = driver.FindElements(By.CssSelector("form#param-list label[data-tooltip]"));
        foreach (IWebElement label in labels)
        {
            expected.Add(label.GetAttribute("data-tooltip"));
            //To get text("Carbon Reduction",...) use label.GetText()
        }
        return expected;
    }
