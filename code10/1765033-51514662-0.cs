            //expected Customer ID needs to be specified here
            String expectedCustID = "12345";
            IWebElement tableElement = driver.FindElement(By.Id("cust-found-table"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
            foreach (IWebElement row in tableRow)
            {
                //Cust Id will be placed in Second Coloum and hence xpath is defined as td[2]
                var custId = row.FindElement(By.XPath(".//td[2]")).Text;
                if (custId.Equals(expectedCustID))
                {
                    row.FindElement(By.TagName("button")).Click();
                }
            }
