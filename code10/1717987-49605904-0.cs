	async void Init()
	{
		if (!(Plugin.Connectivity.CrossConnectivity.Current.IsConnected))
		{
			if (System.IO.File.Exists(path + "App" + "/Data.txt"))
			{
				Device.BeginInvokeOnMainThread(async () =>
				{
					await DisplayAlert("Success", "Saved", "OK");
				});
			}
			else
			{
				Device.BeginInvokeOnMainThread(async () =>
				{
					await DisplayAlert("Oops", "Login Required", "OK");
				});
			}
		}
		else
		{
			GetDetails();
		}
	}
 
