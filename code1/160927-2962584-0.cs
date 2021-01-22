    void Application_BeginRequest(object sender, EventArgs e)
    {
    HttpContext.Current.Items["renderStartTime"] = DateTime.Now;
    }
    void Application_EndRequest(object sender, EventArgs e)
    {
    DateTime start = (DateTime) HttpContext.Current.Items["renderStartTime"];
    TimeSpan renderTime = DateTime.Now - start;
    HttpContext.Current.Response.Write("<!-- Render Time: " + renderTime + " -->");
    }
