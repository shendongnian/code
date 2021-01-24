    CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
    {
    	if (p.Data.ContainsKey("color"))
    	{
    		Device.BeginInvokeOnMainThread(() =>
    		{
    			Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new NotificationsPage()
    			{
    				BackgroundColor = Color.FromHex($"{p.Data["color"]}")
    			});
    		});
    	}
    };
