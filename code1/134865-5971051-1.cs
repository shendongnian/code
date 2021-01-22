    protected bool HeadersWritten { get; private set; }
    void ApplicationInstance_BeginRequest(object sender, EventArgs e)
    {
        HeadersWritten = false;
    }
    void ApplicationInstance_PreSendRequestHeaders(object sender, EventArgs e)
    {
        HeadersWritten = true;
    }
    public void ProcessRequest(HttpContextBase context)
    {
        context.ApplicationInstance.PreSendRequestHeaders += new EventHandler(ApplicationInstance_PreSendRequestHeaders);
        do_some_stuff();
    }
