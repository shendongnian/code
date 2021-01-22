    try
    {
    	if (HttpContext.Current == null)
    		return;
    	if (HttpContext.Current.CurrentHandler == null)
    		return;
    	if (!(HttpContext.Current.CurrentHandler is System.Web.UI.Page))
    		return;
    	if (((System.Web.UI.Page)HttpContext.Current.CurrentHandler).IsCallback)
    		return;
    
    	Server.Transfer("~/Error.aspx");
    }
    catch (Exception abc)
    {
    	// handle it
    }
