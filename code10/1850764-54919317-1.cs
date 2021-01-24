    int numberOfEntriesOnPage = System.Convert.ToInt32(((IJavaScriptExecutor)driver).ExecuteScript("return document.getElementsByName('Entries.index').length"));
    string[] array = new string[numberOfEntriesOnPage];
             for (int a = 0; a < numberOfEntriesOnPage; a++)
                {
                    String script = "return document.getElementsByName('Entries.index')[" + a + "].value";
                    array[a] = ((IJavaScriptExecutor)driver).ExecuteScript(script).ToString();
                    Console.WriteLine("Array value:" + array[a]);
                    string rowTypeID = "Entries_" + array[a] + "__TypeID";
                    select_select_by_index(By.Id("Entries_" + array[a] + "__TypeID"), 1);
                    IWebElement selectOrg = find_element(By.Name("Entries[" + array[a] + "].OrganisationID_input"));
                    selectOrg.Clear();
                    selectOrg.SendKeys("3801 LTD");
                    IWebElement selectInOffice = driver.FindElement(By.Id("Entries_" + array[a] + "__InOffice"));
                    selectInOffice.Clear();
                    selectInOffice.SendKeys("10");
                    IWebElement selectOffsite = driver.FindElement(By.Id("Entries_" + array[a] + "__Offsite"));
                    selectOffsite.Clear();
                    selectOffsite.SendKeys("5");
                    IWebElement comments = driver.FindElement(By.Id("Entries_" + array[a] + "__Comment"));
                    comments.Clear();
                    comments.SendKeys(array[a] + "Manish test");
                 
                    IWebElement save = find_element(By.XPath("//button[@value='SaveDraft']"));
                    save.Click();
                 
                }
     
    public static void select_select_by_index(By by, int index)
        {
            var select = new SelectElement(find_element(by));
            select.SelectByIndex(index);
        }
 
