Device.BeginInvokeOnMainThread(async () =>
{
	try
	{
		using (UserDialogs.Instance.Loading(("Loading...")))
		{
			await Task.Delay(300);
			await _syncController.SyncData();			
			//Your Service code
		}
	}
	catch (Exception ex)
	{
		var val = ex.Message;
		UserDialogs.Instance.Alert("Test", val.ToString(), "Ok");
	}
});
