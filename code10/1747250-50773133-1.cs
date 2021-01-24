    bool isDesignMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime) || DesignMode;
    if (!isDesignMode)
    {
        myconnstr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
    }
