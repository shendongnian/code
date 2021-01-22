    try
    {
        throw new Exception("Original Exception");
    }
    finally
    {
        try
        {
            throw new Exception("Finally Exception");
        }
        catch
        { }
    }
