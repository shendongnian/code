    public override async void OnResume()
    {
        base.OnResume();
    
     	var permissionGranted = await ZXing.Net.Mobile.Android.PermissionsHandler.RequestPermissionsAsync(Activity);
     	if(permissionGranted) {
     		ShowScanFragment();
     	}else{
     		//handle permission denied
     	}
    }
