    // file: Global.asax.cs
    protected void Application_Error(object sender, EventArgs e)
    {
        Exception ex = Server.GetLastError();
        if (ex is HttpException && ((HttpException)ex).GetHttpCode() == 404)
        {
            Server.ClearError(); // important!!!
            Response.Clear();
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            Response.AddHeader("content-type", "application/json");
            Response.Write("{\"Error\":{\"Code\":1234,\"Status\":\"Invalid Endpoint\"}}");
        }
    }
