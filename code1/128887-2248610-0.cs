    public override void Commit(IDictionary savedState)
    {
    	base.Commit(savedState);
    
    	try
    	{
    		var serviceController = new ServiceController("<Insert Service Name>");
    		serviceController.Start();
    	}
    	catch
    	{
    		MessageBox.Show(
    			"There was an error starting the <Insert Service Name> Service. Please manually start it, or restart the computer.");
    	}
    }
