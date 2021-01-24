        public void Application_Error()
        {
        var routeData = new RouteData();
            routeData.Values.Add("controller", "yourControllerNameForError");
            routeData.Values.Add("action", "YourActionMethodeForError");
            if (exception is HttpException httpException)
            {              
                switch (httpException.GetHttpCode())
                {
                    case 404:            
                        routeData.Values["action"] =  "Your404MethodeError";
                        break;                 
                }
            }
     
            Server.ClearError();
            Response.TrySkipIisCustomErrors = true;
            IController errorController = new ErrorController();
            errorController.Execute(new System.Web.Routing.RequestContext (
                 new HttpContextWrapper(Context), routeData));
    }
