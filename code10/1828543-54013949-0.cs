    //template
    string template = context.ActionDescriptor.AttributeRouteInfo.Template;;
        
    //arguments
    IDictionary<string, object> arguments = context.ActionArguments;
            
    //query string
    string queryString= context.HttpContext.Request.QueryString.Value;
