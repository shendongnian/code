	[Test]
	public void StackOverEntry()
	{
		// Wait for the page to appear, test to see if some static (always present) element is available
		AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin Forms!"));
		// Test of the element is on the page (via AutomationId in this class)
		Assert.NotNull(app.Query(c => c.Marked("SOEntry")).FirstOrDefault());
		// Test the the element contains the proper value
		Assert.AreEqual("StackOverflow", app.Query(c => c.Marked("SOEntry")).First().Text);
	}
