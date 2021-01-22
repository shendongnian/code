    Boolean isInWpfDesignerMode   = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
    Boolean isInFormsDesignerMode = (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");
    if (isInWpfDesignerMode || isInFormsDesignerMode)
    {
        // is in any designer mode
    }
    else
    {
        // not in designer mode
    }
