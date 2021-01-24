    enum DisplayMessageEnum
    {
        Success,
        NetworkConnectionFail,
        NetworkTimeout,
        InvalidCredentials,
        // Repeat as necessary
    }
    
    String _displayMessage = "Success";
    public String DisplayMessage
    {
        get => _displayMessage;
        get => SetProperty(ref _displayMessage, value);
    }
    
    ...
    
    void SetDisplayMessage(DisplayMessageEnum displayMessage)
    {
        switch (displayMessage)
        {
            case DisplayMessageEnum.Success:
                DisplayMessage = "Success";
                break;
    
            case DisplayMessageEnum.NetworkConnectionFail:
                DisplayMessage = "Network connection failed.";
                break;
    
            // Repeat for all enum values.
        }
    }
