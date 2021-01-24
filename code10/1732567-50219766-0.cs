    public static void SelectProject()
    {
        IWebElement Table = Driver.Instance.FindElement(By.Id("projectsGrid"));
        ReadOnlyCollection<IWebElement> allRows = 
            Table.FindElements(By.TagName("tr"));
        bool loop = true;
        foreach (IWebElement row in allRows)
        {
            ReadOnlyCollection<IWebElement> cells = 
                row.FindElements(By.TagName("td"));
            foreach (IWebElement cell in cells)
            {
                if (cell.Text.Contains("002032"))
            {
                cell.Click();
                loop = false;
            }
                 if (!loop)
                 break;
            }
            if (!loop)
                    break;
            }
    }
