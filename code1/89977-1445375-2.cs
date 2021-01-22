/* global.asax.cs */
protected void Application_BeginRequest(object sender, EventArgs e)
{
    // ...
    HttpContext.Current.Items["Controller"] = new PageController();
    // ...
}
