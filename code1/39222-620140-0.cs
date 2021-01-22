    using System;
    using System.Web;
    
    static class SessionManager
    {
    	public static String UserName
    	{
    		get
    		{
    			return HttpContext.Current.Session["UserName"].ToString();
    		}
    		set
    		{
    			HttpContext.Current.Session["UserName"] = value;
    		}
    	}
    
            // add other properties as needed
    }
