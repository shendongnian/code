    protected void Application_Start()
    {
        System.Web.HttpContext.Current.Application.Lock();
        System.Web.HttpContext.Current.Application["DbName"] = //call method to set db name;
        System.Web.HttpContext.Current.Application.UnLock();
    }
