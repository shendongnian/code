    public void ProcessFile()
    {
        try
        {
            // do your thing
        }
        catch(Exception ex)
        {
            if(!ProcessFileExceptions(ex))
            {
                throw; // if above hasn't handled exception rethrow
            }
        }
    }
    public static void ProcessFileExceptions(Exception ex)
    {
        if(ex is ArgumentNullException)
        {
            throw new MyException("message", ex); // convert exception if needed
        }
        // and so on
        return true;
    }
