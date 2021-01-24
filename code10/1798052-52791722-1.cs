    int maxRetries = 60;
    int retries = 0;
    bool success = false;
    while (retries < maxRetries)
    {
        try
        {
            retries++;
            srcFile.MoveTo(tmpFilename);
            success = true;
            break;
        }
        catch (Excption ex)
        {
            // Log the error if required
            Thread.Sleep(1000); // Wait 1 second
        }
    }
    if (success == fale)
    {
        // Log the error
        continue; // Skip the file if its still not released
    }
