    public string DeviceModal {
        get {
            // read and return current device model
            return string.IsNullOrEmpty(global::Android.OS.Build.Model) ?
                string.Empty :
                global::Android.OS.Build.Model.StartsWith(global::Android.OS.Build.Manufacturer) ?
                global::Android.OS.Build.Model :
                string.Format("{0} {1}", global::Android.OS.Build.Manufacturer, global::Android.OS.Build.Model);
        }
    }
