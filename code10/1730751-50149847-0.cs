    [Test]
    public void TestAutFullPath()
    {
    	IAut flightsgui= Desktop.LaunchAut("flightsgui");
    	_flightGUIAapplicationWindow = Desktop.Describe<IWindow>(new WindowDescription
    	{
    		ObjectName = @"HP MyFlight Sample Application",
    		FullType = @"window",
    		WindowTitleRegExp = @"HP MyFlight Sample Application"
    	});
    
    	PerformLogin();
    	SearchForFlight();
    	OpenFlightsTable();
    	SelectFlight();
    	FinishOrder();
    	VerifyOrderCompleted();
    	flightsgui.Close();
    }
