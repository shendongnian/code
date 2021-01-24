	public static class IWebElementExtensions {
	    public static IWebElement WithText(this IWebElement webElement, string text) {
    	    if (webElement == null)
        	    return null;
	        return webElement.Text.Equals(text, StringComparison.OrdinalIgnoreCase)
    	        ? webElement : null;
    	}
    // ...
    var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
    var expectedText = "good";
    var element = wait.Until(d => d.FindElement(By.Id("foo-status")).WithText(expectedText));
