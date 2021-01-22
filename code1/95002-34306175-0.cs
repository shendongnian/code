    try 
    {
        HttpContext.Current.Response.Redirect("~/Error.aspx");
    }
    catch (ApplicationException) 
    {
        HttpContext.Current.Response.RedirectLocation =    
                             System.Web.VirtualPathUtility.ToAbsolute("~/Error.aspx");
    }
