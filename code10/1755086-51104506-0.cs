    if (!filterContext.HttpContext.Request.IsAjaxRequest())
    {
        filterContext.HttpContext.Response.StatusCode = 
        (int)System.Net.HttpStatusCode.Unauthorized;
        
        filterContext.HttpContext.Response.ContentType = "application/json";
                
        filterContext.HttpContext.Response.SuppressFormsAuthenticationRedirect = true;
        filterContext.HttpContext.Response.Redirect(null);
    
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        string json = serializer.Serialize(new { IsUnauthenticated = true });
        filterContext.HttpContext.Response.Write(json);
    
        filterContext.HttpContext.Response.End();
    }
