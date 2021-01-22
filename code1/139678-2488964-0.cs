        protected void Application_Error(object sender, EventArgs e)
        {
            HttpException httpException = Server.GetLastError() as HttpException;
            RouteData routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("action", "Index");
            routeData.Values.Add("statusCode", httpException.GetHttpCode().ToString());
            Server.ClearError();
            IController errorController = new MyDomain.Controllers.ErrorController();
            errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }
