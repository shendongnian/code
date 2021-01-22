    public static Action ExitApplication
    {
    	get
    	{
    		return ServiceLocator.GetInstance<Action>("ExitApplication");
    	}
    }
