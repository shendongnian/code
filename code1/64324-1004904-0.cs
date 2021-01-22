    public object CustomObject
    {
        get
        {
            if(HttpContext.Current == null)
            {
                return null;
            }
            return HttpContext.Current.Session["CustomObject"];
        }
        set
        {
            if(HttpContext.Current != null)
            {
                HttpContext.Current.Session["CustomObject"] = value;
            }
        }
    }
