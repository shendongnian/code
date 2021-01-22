    public static UserContext Current 
    { 
        get 
        { 
            // If Session does not yet contain a UserContext instance ...
            if (System.Web.HttpContext.Current.Session["UserContext"] == null) 
            { 
                // ... then create and initialize a new UserContext instance ...
                UserContext uc = new UserContext(); 
                uc.User = new User(); 
                // ... and store it in Session where it will be available for
                // subsequent requests during the same session.
                System.Web.HttpContext.Current.Session["UserContext"] = uc; 
            } 
            // By the time we get here, Session contains a UserContext instance,
            // so return it.
            return (UserContext)System.Web.HttpContext.Current.Session["UserContext"]; 
        } 
    } 
