    UINavigationController originNav;
    UINavigationController newNav;
    public void changeNavigation(){
        newNav = new UINavigationController(new UIViewController2());
        Window.RootViewController = newNav;
    }
    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        originNav = new UINavigationController(new UIViewController1());
            
        Window = new UIWindow(UIScreen.MainScreen.Bounds);
        Window.RootViewController = originNav;
        Window.MakeKeyAndVisible();
    }
