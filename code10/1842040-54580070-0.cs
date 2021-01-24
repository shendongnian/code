    private List<List<string>> GetRecords(IWebElement table)
        {
            List<List<string>> rows = new List<List<string>>(); ;
            //Get Row value
            foreach (var row in table.FindElements(By.TagName("tr")))
            {
                //Configure Number of Col and row
                int cellIndex = 0;
                // Use a list instead of an array
                List<string> cols = new List<string>();
                //Get Cell Data
                foreach (var cell in row.FindElements(By.TagName("td")))
                {
                    // Skip the first column in the row by checking
                    // if the cell index is 0.
                    if (cellIndex != 0)
                    {
                        string cellValue = "";
                        Console.WriteLine(cell);
                        var checkboxes = cell.FindElements(By.CssSelector("input[type='checkbox']"));
                        if (checkboxes.Count > 0)
                        {
                            bool isChecked = false;
                            isChecked = checkboxes[0].Selected;
                            cellValue = isChecked.ToString();
                        }
                        else
                        {
                            cellValue = cell.Text;
                        }
                        cols.Add(cellValue);
                    }
                    cellIndex++;
                }
                rows.Add(cols);
            }
            return rows;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Configure to Hide CMD
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            
            //Configure to Hide Chrome
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--headless");
            //HIDING CHROME UN-COMMNET THE SECOND ONE TO SHOW
            //IWebDriver driver = new ChromeDriver(chromeDriverService, option);
            IWebDriver driver = new ChromeDriver();
            driver.Url = "**************";
            driver.Manage().Window.Maximize();
            driver.SwitchTo().DefaultContent();
            //Log-in
            driver.FindElement(By.Id("username")).SendKeys("*****");
            driver.FindElement(By.Id("password")).SendKeys("******" + OpenQA.Selenium.Keys.Enter);
            //Entering Access Code
            driver.FindElement(By.Id("password")).SendKeys("*******");
            driver.FindElement(By.Id("accesscode")).SendKeys("********" + OpenQA.Selenium.Keys.Enter);
            //go to CustomerList
            driver.Navigate().GoToUrl("***********");
            driver.Navigate().GoToUrl("*****************");
            //Wait till load 3 seconds
            waitOnPage(2);
            DataTable dt = new DataTable();
            var header = driver.FindElement(By.CssSelector("#gridComponent > div.k-grid-header"));
            foreach (var row in header.FindElements(By.TagName("tr")))
            {
                //Configure Number of Col and row
                int cellIndex = 0;
                string[] arr = new string[32];
                //Get Cell Data
                foreach (var cell in row.FindElements(By.TagName("th")))
                {
                    // Check the header cell for a checkbox child. If no
                    // such child exists, add the column.
                    var headerCheckboxes = cell.FindElements(By.CssSelector("input[type='checkbox']"));
                    if (headerCheckboxes.Count == 0)
                    {
                        //Number of Col Data Load
                        if (cellIndex <= 29)
                        {
                            arr[cellIndex] = cell.Text;
                            dt.Columns.Add(cell.Text);
                        }
                        else
                        cellIndex++;
                    }
                }
                Console.WriteLine(arr);
            }
            var table = driver.FindElement(By.CssSelector("#gridComponent"));
            
            List<List<string>> records = GetRecords(table);
            // Supposing you want the footer information
            var lastPageStr = table.FindElement(By.ClassName("k-pager-last")).GetAttribute("data-page");
            var lastPage = Convert.ToInt16(lastPageStr);
            // You can select other info lik this
            // class="k-link k-pager-nav" data-page="1" 
            driver.FindElement(By.CssSelector("#gridComponent > div.k-pager-wrap.k-grid-pager.k-widget.k-floatwrap > ul > li:nth-child(3)")).Click();
            // Cycle over the pages
            for (int p = 0; p < (lastPage - 1); p++)
            {
                driver.FindElement(By.CssSelector("#gridComponent > div.k-pager-wrap.k-grid-pager.k-widget.k-floatwrap > a:nth-child(4) > span")).Click();
                waitOnPage(2);
                var rows = GetRecords(table);
                records.AddRange(rows);
            }
            // Add all rows to DT
            //dt.Rows.Add(records[4].ToArray());
            foreach(var row in records)
            {
                dt.Rows.Add(row.ToArray());
            }
            dataGridView1.DataSource = dt;
        }
