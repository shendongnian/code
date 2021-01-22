    if (plugin.HasHandlerForMouseClick)
    {
        _userInitiated = true;
        try
        {
            plugin.HandleMouseClick();
        }
        finally
        {
            _userInitiated = false;
        }
    }
