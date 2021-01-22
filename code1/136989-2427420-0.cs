        bool isDesignMode = 
        LicenseManager.UsageMode == LicenseUsageMode.Designtime ||  
        Debugger.IsAttached == true || 
        Pocess.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"); 
  
