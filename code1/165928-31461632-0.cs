    try
    {
        DateTime.Now.ToString(tmpFormatSpec);                    
    }
    catch (Exception)
    {
        // the format spec is known to be bad
    }
