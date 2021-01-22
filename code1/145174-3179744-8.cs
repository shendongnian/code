    protected void Application_Start(object sender, EventArgs e)
    {
    	yourLibraryNamespace.ContextWrapper2.IsIis7IntegratedAppStart = true;
    	//...
    	yourLibraryNamespace.yourClass.Init();
    	//...
    	yourLibraryNamespace.ContextWrapper2.IsIis7IntegratedAppStart = false;
    }
