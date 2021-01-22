    // load settings
    WriteSettings(currentUser.Settings ?? new Settings());
    
    // example of some readonly property
    public string DisplayName
    {
        get 
        {
             return (currentUser ?? User.Guest).DisplayName
        }
    }
