    public static T GetItem<T>(string key)
        where T : new()
    {
        return ((T)HttpContext.Current.Session[key]) ?? new T();
    }
