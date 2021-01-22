    public void ValidateRequest()
    {
        if(!this.UseRequestTracker || requestTracker == null)
            return;
        if (RequestId < requestTracker.CurrentRequestId())
        {
            httpContext.Response.Write("Please do not refresh so fast!");//TODO add automatic refresh to this page
            httpContext.Response.End();
        }
    }
    public string Foo()
    {
        ValidateRequest();
        string ret;
        using (var apiConn = apiPool.getConn())
        {
            lock (apiConn)
            {
                ret = (string)apiConn.Call("bar");
            }
        }
        return ret;
    }
