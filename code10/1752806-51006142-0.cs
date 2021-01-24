    protected async override void OnStart()
    {
        if (Settings.LocationTracking == true)
                {
                    await LocationControls.StartListening(); 
                }
    }
