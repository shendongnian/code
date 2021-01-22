    public static bool IsDesignTime(this Control control)
    {
    	if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
    	{
    		return true;
    	}
    
    	if (control.Site != null && control.Site.DesignMode)
    	{
    		return true;
    	}
    
    	var parent = control.Parent;
    	while (parent != null)
    	{
    		if (parent.Site != null && parent.Site.DesignMode)
    		{
    			return true;
    		}
    		parent = parent.Parent;
    	}
    	return false;
    }
