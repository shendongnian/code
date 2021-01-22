    protected void Application_Error(object sender, EventArgs e)
    {
        Log.Error("*** Application_Error ***");
        Exception baseException = Server.GetLastError().GetBaseException();
        HttpException httpException = baseException as HttpException;
        if (httpException != null)
        {
            int httpCode = httpException.GetHttpCode();
            Log.ErrorFormat("HTTPEXCEPTION: {0} : {1}", httpCode, HttpContext.Current.Request.RawUrl);
            if (httpCode == 404)
            {
                     ...
