    protected void Application_Error(object sender, EventArgs e)
    {
        try
        {
            Exception lastError = Server.GetLastError().GetBaseException();
            if (lastError is HttpException && ((HttpException)lastError).GetHttpCode() == 404)
                return;
            if (Request.UrlReferrer != null)
                lastError.Data.Add("Referrer", Request.UrlReferrer);
            if (Request.RawUrl != null)
                lastError.Data.Add("Page", Request.RawUrl);
            if (Request.UserHostAddress != null)
                lastError.Data.Add("Client IP", Request.UserHostAddress);
            if (Request.UserAgent != null)
                lastError.Data.Add("UserAgent", Request.UserAgent);
            if (User != null && User.Identity != null && !string.IsNullOrEmpty(User.Identity.Name))
                lastError.Data.Add("User", User.Identity.Name);
            Log.Error("Application_Error trapped at Global.asax", lastError);
        }
        // ReSharper disable EmptyGeneralCatchClause
        catch { } // Intentionally empty catch clause as this is the catchall exception handler. If it fails, the sky has fallen.
        // ReSharper restore EmptyGeneralCatchClause
    }
