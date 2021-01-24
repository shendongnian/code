    public override void ViewDidLoad()
    {
    	base.ViewDidLoad();
    	//Initial setup check
    	dataBase.SetBool(false, "setUpComplete");
    	if (dataBase.BoolForKey("setUpComplete") == false)
    	{
    	   var objSetUpViewController=new SetUpViewController()
    	   this.NavigationController.PushViewController (objSetUpViewController, true);
    	}
    	else
    	{
           //If setup completed on HomeViewController
    	   var objHomeViewController=new HomeViewController()
    	   this.NavigationController.PushViewController (objHomeViewController, true);
    	}
    }
