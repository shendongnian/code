    private IList<IWebElement> ListOfElements => Driver.FindElements(By.XPath("//p[contains(@id,'r-number-')]"));
    //this finds all the p elements on the page with an id that contains r-number-
        public void ClickEachOne()
        {
            // click each element in that list
            foreach (var element in ListOfElements)
            {
                element.Click();
            }
        }
