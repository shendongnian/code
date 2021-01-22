    protected void Application_Error(object sender, EventArgs e)
    {
        var error = Server.GetLastError();
        Server.ClearError();
        Response.ContentType = "text/plain";
        Response.Write(error.ToString());
        Response.End();
    }
