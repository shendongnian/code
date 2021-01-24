	public class ExtendedElement : RemoteWebElement
	{
	    public static ExtendedElement Get(IWebElement element)
	    {
	    	RemoteWebDriver driver = (RemoteWebDriver)element.WrappedDriver;
	    	string id = (string)typeof(RemoteWebElement)
	    					.GetProperty("Id", BindingFlags.NonPublic | BindingFlags.Instance)
	    					.GetValue(element, null);
	        return new ExtendedElement(driver, id);
	    }
	    public ExtendedElement(RemoteWebDriver driver, string id)
	        : base(driver, id)
	    { }
	}
