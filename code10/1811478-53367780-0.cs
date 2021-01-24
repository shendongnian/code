    private async void Button_Clicked(object sender, EventArgs e)
        {
            await GetPermissions();
        }
  
    public static async Task<bool> GetPermissions()
        {
            bool permissionsGranted = true;
            var permissionsStartList = new List<Permission>()
            {
                Permission.Location,
                Permission.LocationAlways,
                Permission.LocationWhenInUse,
                Permission.Storage,
                Permission.Camera
            };
            var permissionsNeededList = new List<Permission>();
            try
            {
                foreach (var permission in permissionsStartList)
                {
                    var status = await CrossPermissions.Current.CheckPermissionStatusAsync(permission);
                    if (status != PermissionStatus.Granted)
                    {
                        permissionsNeededList.Add(permission);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            var results = await CrossPermissions.Current.RequestPermissionsAsync(permissionsNeededList.ToArray());
            try
            {
                foreach (var permission in permissionsNeededList)
                {
                    var status = PermissionStatus.Unknown;
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(permission))
                        status = results[permission];
                    if (status == PermissionStatus.Granted || status == PermissionStatus.Unknown)
                    {
                        permissionsGranted = true;
                    }
                    else
                    {
                        permissionsGranted = false;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return permissionsGranted;
        }
