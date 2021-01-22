    protected void Application_Error(object sender, EventArgs e)
    {
        var exception = Server.GetLastError();
        Response.Clear();
        var httpException = exception as HttpException;
        var routeData = new RouteData();
        routeData.Values.Add("controller", "Error");
    
        if(httpException != null )
        {
            switch( httpException.GetHttpCode() )
            {
                case 404:
                    // Page not found.
                    routeData.Values.Add("action", "HttpError404" );
                    break;
                case 500:
                    // Server error.
                    routeData.Values.Add("action", "HttpError500" );
                    break;
                default:
                    routeData.Values.Add("action", "General" );
                    break;
            }
        }
    
        routeData.Values.Add("error", exception);
        Server.ClearError();
        var errorController = new ErrorController();
        errorController.Execute(new RequestContext(
            new HttpContextWrapper(Context), routeData ) );
    }
