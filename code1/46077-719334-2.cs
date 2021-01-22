    protected void Application_Error(object sender, EventArgs e)
    {
        var error = Server.GetLastError();
        Server.ClearError();
        Response.ContentType = "text/plain";
        Response.Write(error ?? (object) "unknown");
        Response.End();
    }
Or use Debug.WriteLine() instead of working with debugger in this scenario.
