    if (Properties.Settings.Default.UpgradeSettings)
    {
       Properties.Settings.Default.Upgrade();
       Properties.Settings.Default.UpgradeSettings = false;
    }
