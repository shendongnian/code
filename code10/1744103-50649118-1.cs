    	public App ()
    	{
    		InitializeComponent ();
    		
            var navPage = new NavigationPage(new App14.MainPage()); 
            Application.Current.MainPage = navPage; 
    
            navPage.PushAsync(new Page1());
    	}
    }
