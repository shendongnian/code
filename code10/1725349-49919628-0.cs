    protected override async void OnStart()
    {
       var appManager = AppManager.Instance;
       await appManager.InitializeAsync();
       if(appManager .JobExists("JobA"))
       {
          MainPage = new PageA();
       }
       else
       {
          MainPage = new PageB();
       }
    }
