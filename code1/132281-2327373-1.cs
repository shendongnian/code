    HttpSessionStateBase _session;
    public HttpSessionStateBase Session
    {
        get{
            return _session ?? (_session = new HttpSessionStateWrapper(HttpContext.Current.Session));
        }
        set{
            _session = value;
        }
    }
