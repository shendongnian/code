    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
    {
        if (requestCode == REQUEST_LOCATION) 
        {
            // Received permission result for camera permission.
            Log.Info(TAG, "Received response for Location permission request.");
    
            // Check if the only required permission has been granted
            if ((grantResults.Length == 1) && (grantResults[0] == Permission.Granted)) {
                // Location permission has been granted, okay to retrieve the location of the device.
                Log.Info(TAG, "Location permission has now been granted.");
                Snackbar.Make(layout, Resource.String.permision_available_camera, Snackbar.LengthShort).Show();            
            } 
            else 
            {
                Log.Info(TAG, "Location permission was NOT granted.");
                Snackbar.Make(layout, Resource.String.permissions_not_granted, Snackbar.LengthShort).Show();
            }
        } 
        else 
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
