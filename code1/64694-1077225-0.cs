    void Page_Load(...) {
    
        if(Request.Path.EndsWith("default.aspx", true/*case-insensitive*/, null)) {
           Response.StatusCode = 301;
           Response.StatusDescription = "Moved Permanently";
           Response.Headers.Add("Location", "/");
           HttpContext.Current.ApplicationInstance.CompleteRequest(); // end the request
        }
    
        // do normal stuff here
    }
