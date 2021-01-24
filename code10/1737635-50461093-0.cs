    _mediaCapture = new MediaCapture();
    try
    { 
        await _mediaCapture.InitializeAsync(new MediaCaptureInitializationSettings
        {
            StreamingCaptureMode = StreamingCaptureMode.Video 
        });
        _isInitialized = true;
    }
    catch (UnauthorizedAccessException ex)
    {
        Debug.WriteLine("The app was denied access to the camera");
    }
 
