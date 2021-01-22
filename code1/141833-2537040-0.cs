    public string ModuleName { 
        get { return "MyDownloadModule"; }
    }
    public void Init(HttpApplication app) {
        // Add an event handle which is called at the beginning of each request
        app.BeginRequest += new EventHandler(this.AppBeginRequest);
    }
    //
    // Our event handler for the BeginRequest event
    //
    private void AppBeginRequest(Object source, EventArgs e)
    {
        HttpRequest request = app.Context.Request;
        //
        // Is this a file download?
        //
        if (request.AppRelativeCurrentExecutionFilePath == "~/downloads") // or whatever
        {
              // this is where you work your GUID inspecting magic
        }
    }
