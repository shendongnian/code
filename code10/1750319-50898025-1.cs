    public static void Main()
	{
		ViewClass v = new ViewClass();
	    v.ProductSaveButtonEventRaised += ViewEventHandler;
		v.LogicWhichRaiseAnEvent("view");
		
		PresenterClass p = new PresenterClass();
		p.ProductSaveButtonEventRaised += PresenterEventHandler;
		p.LogicWhichRaiseAnEvent("presenter");
	}
	
	static void ViewEventHandler(object sender, EventArgs e)
	{
		Console.WriteLine(((ViewClass)sender).Name);
	}
	static void PresenterEventHandler(object sender, EventArgs e)
	{
		Console.WriteLine(((PresenterClass)sender).Name);
	}
