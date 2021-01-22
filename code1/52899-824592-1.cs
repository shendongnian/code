    private bool _LoadComplete;
    void OnFormLoad(Object sender, EventArgs e)
    {
        _LoadComplete = true;
        InitializeControls();
        _LoadComplete = false;
    }
    void InitializeControls()
    {
        // Populate Controls
    }
    void OnSomeControlEvent()
    {
        if (_LoadComplete)
        {
             // Handle the event
        }
    }
