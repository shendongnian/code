    // Ok, this is stupid, but I can't find any other way to do this
    // Detect whether we're in integrated mode or not
    #warning GIANT HACK FOR IIS7 HERE
    try
    {
        var x = HttpContext.Current.CurrentNotification;
        _isIntegratedMode = true;
    }
    catch (PlatformNotSupportedException)
    {
        _isIntegratedMode = false;
    }
    catch (NullReferenceException)
    {
        _isIntegratedMode = true;
    }
