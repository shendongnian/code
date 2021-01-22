    if (Properties.Settings.Value.CallUpgrade)
    {
        Properties.Settings.Value.Upgrade();
        Properties.Settings.Value.CallUpgrade = false;
    }
