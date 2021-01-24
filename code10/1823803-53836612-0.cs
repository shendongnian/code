    private IList<IWebElement> ListOfElements => Driver.FindElements(By.XPath("//p[contains(@id,'r-number-')]"));
        public void ClickEachOne()
        {
            foreach (var element in ListOfElements)
            {
                element.Click();
            }
        }
