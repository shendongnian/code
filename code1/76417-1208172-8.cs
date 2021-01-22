    private Site _site;
    public static IActiveContext Current
    {
        get
        {
            IActiveContext activeContext;
            activeContext = Context.Items["ActiveContext"] as ActiveContext;
            if (activeContext == null)
            {
                activeContext = new ActiveContext();
                Context.Items["ActiveContext"] = activeContext;
            }
            return activeContext;
        }
    }
    public Person AuthenticatedUser
    {
        get
        {
            Person person = Context.Session["AuthenticatedUser"] as Person;
            return person;
        }
        set { Context.Session["AuthenticatedUser"] = value; }
    }
    public Site Site
    {
        get { return Context.Items["CurrentSite"] as Site; }
        set { Context.Items["CurrentSite"] = value; }
    }
    private static HttpContext Context
    {
        get
        {
            HttpContext context = HttpContext.Current;
            if (context == null)
                throw new Exception("HttpContext is null");
            return context;
        }
    }
}
