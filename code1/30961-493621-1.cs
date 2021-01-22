    public void Init(HttpApplication context)
    {
        context.BeginRequest += new EventHandler(Begin_Request);
        IHttpModule sessionModule = context.Modules["Session"];
        if(sessionModule != null && 
            sessionModule.GetType() == typeof(System.Web.SessionState.SessionStateModule))
        {
            (sessionModule as System.Web.SessionState.SessionStateModule).Start 
              += new EventHandler(CustomHttpModule_Start);
        }
    }
