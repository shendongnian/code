    public static void SelectProject()
    {
        // Boolean flag for when we break from inner loop
        bool done = false;
        IWebElement Table = Driver.Instance.FindElement(By.Id("projectsGrid"));
        ReadOnlyCollection<IWebElement> allRows = Table.FindElements(By.TagName("tr"));
        foreach (IWebElement row in allRows)
        {
            ReadOnlyCollection<IWebElement> cells = row.FindElements(By.TagName("td"));
            foreach (IWebElement cell in cells)
            {
                if (cell.Text.Contains("002032"))
                {
                    cell.Click();
                    done = true;
                    break;
                }
            }
 
            // Check if the inner loop 
            // broke, if so also break here
            if (done == true) {
                break;
            }
        }
    }
