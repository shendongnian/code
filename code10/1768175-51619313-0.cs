    string Flippo1SN = "GF02";
    var props = Properties.Settings.Default;
    foreach(var prop in props.Properties)
    {
        var settingProperty = (SettingsProperty)prop;
        if (settingProperty.Name == Flippo1SN)
        {
            // Now you found the property that matches Flippo1SN.
            // Get its value.
            var value = settingProperty.DefaultValue;
        }
    }
