    if (RunningAsAdmin) // save value in main exe's config file
    {
        SaveUserSettingDefault(@"MyAssembly.Properties.Settings", @"SQLConnectionString", theNewConnectionString);
    }
    else // save setting in user's config file
    {
        Settings.Default. SQLConnectionString = theNewConnectionString;
        Settings.Default.Save();
    }
