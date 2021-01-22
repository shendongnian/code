    protected override void OnStart(string[] args)
    {
        if (ObjectFolderApp.Initialize())
        {
            SomeApp.StartMonitorAndWork();
            base.OnStart(args);
        }
        else
        {
            throw new Exception("What went wrong");
        }
    }
