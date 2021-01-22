        void Application_Error(object sender, EventArgs e) 
    {
        Exception objErr = Server.GetLastError().GetBaseException();
        string err = "Error Caught in Application_Error event\n" +
                "Error in: " + Request.Url.ToString() +
                "\nError Message:" + objErr.Message.ToString() +
                "\nStack Trace:" + objErr.StackTrace.ToString();
        System.Diagnostics.EventLog.WriteEntry("Sample_WebApp", err, System.Diagnostics.EventLogEntryType.Error);
        Server.ClearError();
        Response.Redirect(string.Format("{0}?exceptionMessage={1}", System.Web.VirtualPathUtility.ToAbsolute("~/ErrorPage.aspx"), objErr.Message));
    }
