    private readonly string[] Permissions =
    {
        Manifest.Permission.Bluetooth,
        Manifest.Permission.BluetoothAdmin,
        Manifest.Permission.AccessCoarseLocation,
        Manifest.Permission.AccessFineLocation
    };
    protected override void OnCreate(Bundle savedInstanceState)
    {
        ...
        CheckPermissions();
        LoadApplication(new App());
    }
    private void CheckPermissions()
    {
        bool minimumPermissionsGranted = true;
        foreach (string permission in Permissions)
        {
            if (CheckSelfPermission(permission) != Permission.Granted)
            {
                minimumPermissionsGranted = false;
            }
        }
        // If any of the minimum permissions aren't granted, we request them from the user
        if (!minimumPermissionsGranted)
        {
            RequestPermissions(Permissions, 0);
        }
    }
