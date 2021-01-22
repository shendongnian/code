    public object GetFromRequestOrSession(string key)
    {
        // if the same key exists in Request and Session
        // then Request will currently be given priority
        object o = HttpContext.Current.Request[key];
        if (o == null)
        {
            o = HttpContext.Current.Session[key];
        }
        return o;
    }
