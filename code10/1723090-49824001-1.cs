	[Test]
	public void StackOverEntry()
	{
		// Wait for the page to appear, test to see if some static (always present) element is available
		AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin Forms!"));
		var elementQuery = app.Query(c => c.Marked("SOEntry"));
		var elementAvailable = elementQuery.Any();
		string elementValue = "";
		if (elementAvailable)
			elementValue = elementQuery.First().Text;
		
		Assert.IsTrue(elementAvailable && elementValue == "StackOverflow", "Not available and/or correct");
	}
