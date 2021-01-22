    public static void Dispose()
    {
        //Cleanup this object so that GC can reclaim space
        System.Web.HttpContext.Current.Session.Remove(SESSION_SINGLETON);
    }
