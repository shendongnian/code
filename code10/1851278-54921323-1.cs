       public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    
    
        void RequestSendSMSPermission()
        {
            Log.Info("MainActivity", "CAMERA permission has NOT been granted. Requesting permission.");   
            if (ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission.SendSms))
            {
                Log.Info("MainActivity", "Displaying camera permission rationale to provide additional context.");
                Snackbar.Make(layout, "Camera permission is needed to show the camera preview.",
                    Snackbar.LengthIndefinite).SetAction("OK", new Action<View>(delegate (View obj) {
                        ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.SendSms }, REQUEST_SENDSMS);
                    })).Show();
            }
            else
            {
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.SendSms }, REQUEST_SENDSMS);
            }
        }
