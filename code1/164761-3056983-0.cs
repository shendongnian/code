    public static T Get<T>(string key)
    {
        if (...)
            return 
              (T) Convert.ChangeType(System.Web.HttpContext.Current.Session[key],
                                     typeof(T));
    
        ...
    }
