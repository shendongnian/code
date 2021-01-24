    public override void ViewDidLoad()
    {
        base.ViewDidLoad();
        if(user.SetupExist())
        {
            App.Current.MainPage = new HomePage();
        }else{
         App.Current.MainPage = new SettingPage();
        }
    }
    
           
