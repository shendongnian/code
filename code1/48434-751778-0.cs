    public void doSomething()
    {
        try
        {
           // actual code goes here
        }
        catch (Exception ex)
        {
            LogException (ex);  // Log error...
            throw;
        }
    }
