    SelectElement test = new SelectElement(driver.FindElement(By.CssSelector(".ui-menu-item > div")));
    IList<IWebElement> size = test.Options;
    int myitem = size.Count;
    
    for (int i = 0; i < myitem; i++)
    {
        String value = test.ElementAt(i).Text;
        Console.WriteLine(value);
    	if (val.Equals(sItemText, StringComparison.InvariantCultureIgnoreCase))
    	{
    	val.click
    	
    	}
    	else{
    	 Console.WriteLine("Not present");
    	}
    }
