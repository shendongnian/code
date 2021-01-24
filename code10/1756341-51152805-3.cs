    var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
        if (status != PermissionStatus.Granted)
        {
            if(await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Storage))
            {
                await DisplayAlert("Need storage, "Request storage permission", "OK");
            }
    
            var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
    		//Best practice to always check that the key exists
    		if(results.ContainsKey(Permission.Storage))
            	status = results[Permission.Storage];
        }
