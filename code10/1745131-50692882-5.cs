    if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
    {
        var authOptions = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound;
        UNUserNotificationCenter.Current.RequestAuthorization(authOptions, (granted, error) => {
            Console.WriteLine(granted);
        });
        UNUserNotificationCenter.Current.Delegate = new MyNotificationCenterDelegate();
    }
