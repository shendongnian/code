    public void readFile()
    {
        try
        {
            // Perform IO action
        }
        catch ( FileNotFoundException ex )
        {
            // Perform error recovery e.g. create a default file   
        }
        catch ( Exception ex )
        {
            // Cant perform any error recovery at this level so throw the exception to allow the calling code to deal with it
            throw ex;
        }
     }
