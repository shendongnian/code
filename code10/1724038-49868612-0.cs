    // Initialize MediaCapture
    try
    {
        await _mediaCapture.InitializeAsync(settings); 
        _isInitialized = true;
    }
    catch (UnauthorizedAccessException ex)
    {
        Debug.WriteLine("The app was denied access to the camera");
    }
