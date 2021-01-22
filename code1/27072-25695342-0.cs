    try
    {
        // do file IO here
    }
    catch (IOException e)
    {
        if (e.HResult == 32) // 32 = Sharing violation
        {
            // Recovery logic goes here
        }
        else
        {
            throw; // didn't need to catch this
        }
    }
