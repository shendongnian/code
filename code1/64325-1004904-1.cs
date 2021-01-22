    public object CustomObject
    {
        get
        {
            if(System.Web.HttpContext.Current == null)
            {
                return null;
            }
            return System.Web.HttpContext.Current.Session["CustomObject"];
        }
        set
        {
            if(System.Web.HttpContext.Current != null)
            {
                System.Web.HttpContext.Current.Session["CustomObject"] = value;
            }
        }
    }
