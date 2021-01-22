    public static ErrorControl _errorDisplay = null;
    public static logError(string msg)
    {
        // log the error
        // display the error
        if (_errorDisplay != null)
        {
            _errorDisplay.DisplayError(msg);
        }
    }
