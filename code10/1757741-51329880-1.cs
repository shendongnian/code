        [Then(@"the '(.*)' dropdown should contain the values")]
        public void ThenTheDropdownShouldContainTheValues(string p0, Table table)
        {
            var dropdown = new SelectElement(Selenium.FindElement(By.Name(p0)));
            var dropDownTextValues = dropdown.Options.Select(webElement => webElement.Text).ToList();
            var textValues = table.Rows.Select(x => x[1]).ToList();
            CollectionAssert.AreEquivalent(dropDownTextValues, textValues);
            var dropDownValues = dropdown.Options.Select(webElement => webElement.GetAttribute("value")).ToList();
            var values = table.Rows.Select(x => x[0]).ToList();
            if (values.All(x => x == String.Empty))
                return;
            CollectionAssert.AreEquivalent(dropDownValues, values);
        }
