    public string WindowTitle
    {
        get
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            return "MyTitle v" + version;
        }
    }
