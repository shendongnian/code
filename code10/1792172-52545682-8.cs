    public void ProcessFile()
    {
        try
        {
            // do your thing
        }
        catch(Exception ex) when(IsFileException(ex))
        {
            if(!ProcessFileExceptions(ex))
            {
                throw; // if above hasn't converted exception rethrow
            }
        }
    }
    
    public static bool IsFileException(Exception ex)
    {
        return ex is ArgumentNullException || ex is FileNotFoundException; // .. etc
    }
    
