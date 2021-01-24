    public void SelectProject()
    {
        IReadOnlyCollection<IWebElement> e = Driver.Instance.FindElements(By.XPath("[@id='projectsGrid']//td[.='002032']"));
        if (e.Any())
        {
            e.ElementAt(0).Click();
        }
    }
