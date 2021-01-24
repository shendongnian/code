    public override void ViewDidLoad()
    {
        base.ViewDidLoad();
        dataBase.SetBool(false, "setUpComplete");
    	var rootNavigationController = new UINavigationController(); 
        if (dataBase.BoolForKey("setUpComplete") == false)
        {
           var objSetUpViewController=new SetUpViewController()
           rootNavigationController.NavigationController.PushViewController (objSetUpViewController, true);
        }
        else
        {
           var objHomeViewController=new HomeViewController()
           rootNavigationController.NavigationController.PushViewController (objHomeViewController, true);
        }
    }
