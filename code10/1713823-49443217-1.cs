            public void TakePhoto()
            {
                if (ContextCompat.CheckSelfPermission(Application.Context, Manifest.Permission.Camera) != (int)Permission.Granted)
                {
                    var requiredPermissions = new String[] { Manifest.Permission.Camera };
                    var activity = Xamarin.Forms.Forms.Context as Activity;
                    ActivityCompat.RequestPermissions(activity, requiredPermissions, 100);
                }    
                while (ContextCompat.CheckSelfPermission(Application.Context, Manifest.Permission.Camera) != (int)Permission.Granted)
                {
                     //waiting user permission
                }    
                //Other code   
                //...
                //... 
            }
