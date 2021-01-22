    try { /* init code here */ }            
    catch (Exception ex)
    {
        // Passing original exception as inner exception
        Exception ocrex = new OCRException("Engine failed to initialize", ex);
        try
        {
            _DeinitializeEngine();
        }
        catch (Exception ex2)
        {
            // Passing initialization failure as inner exception
            ocrex = new OCRException("Failed to deinitialize engine!", ocrex);            
        }
        throw ocrex;
    }
