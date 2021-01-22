    try
    {
    }
    catch(Exception ex)
    {
        bool rethrow = ExceptionPolicy.HandleException(ex, "My Custom Policy");
        if (rethrow)
        {
            throw;
        }
    }
    finally
    {
    }
