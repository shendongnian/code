    string Flippo1SN = "GF02";
    foreach (SettingsProperty prop in Properties.Settings.Default.Properties)
    {
        if (prop.Name == Flippo1SN)
        {
            if (int.TryParse(prop.DefaultValue.ToString(), out int result))
            {
                if (result == 0)
                {
                    // The value is zero.
                }
            }
        }
    }
