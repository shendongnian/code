    bool isAuthorized = false;
    
    foreach(string role in AuthRoles)
    {
      if(filterContext.HttpContext.User.IsInRole(role))
        isAuthorized = true;
    }
 
