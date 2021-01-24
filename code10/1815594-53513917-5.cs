    private bool IsNotification=false;
    private object NotificationData;
       protected override void OnCreate(Bundle savedInstanceState)
     {
       TabLayoutResource = Resource.Layout.Tabbar;
       ToolbarResource = Resource.Layout.Toolbar;
        base.OnCreate(savedInstanceState);
        global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
        FirebasePushNotificationManager.ProcessIntent(this, Intent);    
        CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
        {
           System.Diagnostics.Debug.WriteLine("NOTIFICATION RECEIVED", p.Data);
           NotificationData = p.Data;
           IsNotification=false;
           DependencyService.Get<IToast>().DisplayTost("opened notifications");           
        };
       if(IsNotification)
        LoadApplication(new App(IsNotification,NotificationData)); 
       else
        LoadApplication(new App());
     }
