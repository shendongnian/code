	public class ExtendedElement : RemoteWebElement
	{
		
	    public static ExtendedElement Get(IWebElement element)
	    {
	        return new ExtendedElement((RemoteWebElement)element);
	    }
		public ExtendedElement(RemoteWebElement element)
			: base((RemoteWebDriver)element.WrappedDriver,
                   ((IWebElementReference)element).ElementReferenceId)
		{ }
	}
