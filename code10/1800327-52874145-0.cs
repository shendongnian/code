        [When(@"I can see buttons:")]
        [Then(@"I can see buttons:")]
        public void ICanSeeButtons(Table table)
        {
            foreach (var row in table.Rows)
            {
                var buttonValue = row["buttons"];
                var field = this.Page.ButtonByText.With(buttonValue);
                field.Assert.Is.Displayed();
            }
        }
