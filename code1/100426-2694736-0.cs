    // Each SettingsProperty in props has a corresponding DefaultValue property
    // which returns (surprise!) the default value from the app.config file.
    SettingsPropertyCollection props = FormsApp.Properties.Settings.Default.Properties;
    
    // Each SettingsPropertyValue in propVals has a corresponding PropertyValue
    // property which returns the value in the user.config file, if one exists.
    SettingsPropertyValueCollection propVals = FormsApp.Properties.Settings.Default.PropertyValues;
