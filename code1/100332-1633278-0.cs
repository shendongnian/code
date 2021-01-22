    private class State
    {
        public HttpContext Context { get; set; }
        public RequestService Service { get; set; }
    }
    
    public void ProcessRequest(HttpContext context)
    {
        throw new NotImplementedException();
    } 
    public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, Object extraData)
    {
        // Don't use using block or it will dispose the service before you can call EndGetFile
        var state = new State
        {
            Service = new RequestService(),
            Context = context
        };
        // Pass cb here and not EndProcessRequest
        return state.Service.BeginGetFile(cb, state);
    }
    
    public void EndProcessRequest(IAsyncResult result)
    {
        State state = result.AsyncState as State;
        // Be carefull as this may throw: it is best to put it in a try/finally block
        // so that you dispose properly of the service
        byte[] buffer = state.Service.EndGetFile(result);
        state.Service.Dispose();
        state.Context.Response.ContentType = "application/octet-stream";
        state.Context.Response.AddHeader("Content-Disposition", "attachment; filename=attachment.pdf");
        // Write directly into the output stream, and don't call Flush
        state.Context.Response.OutputStream.Write(buffer, 0, buffer.Length);
    }
    public bool IsReusable 
    { 
        get { return false; } 
    }
