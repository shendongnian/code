    string s = System.Web.Configuration.ConfigurationManager.AppSettings["myKey"].ToString();
    if (!String.IsNullOrEmpty(s))
    {
    	// Key exists
    }
    else
    {
    	// Key doesn't exist
    }
