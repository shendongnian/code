    //Global.asax
    static string GetUserIp()
    {
        return System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
    }
    protected void Application_Start(object sender, EventArgs e)
    {
         LoggerDll.UserIpGetter = GetUserIp;
    }
