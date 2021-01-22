    protected override WebRequest GetWebRequest(Uri uri)
    {
        //only perform the initialization once
        if (!hasBeenInitialized)
        {
            Initialize();
        }
        return base.GetWebRequest(uri);
    }
    bool hasBeenInitialized = false;
    private void Initialize()
    {
        //do your initialization here...
        hasBeenInitialized = true;
    }
