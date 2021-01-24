    if (UIApplication.SharedApplication.ApplicationState == UIApplicationState.Active) 
    {
        //You app is in Foreground state.
        //Process the Pushnotification data, or show alert.
    } 
    else 
    {
        //Your app was in Background state
     	//Application is opened by clicking on the push notification.
    }
