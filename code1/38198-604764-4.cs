    private bool SomeLockingMethod(object foo)
    {
        // Verify foo is valid
        try
        {
           lock(foo)
           {
              // Do stuff
           }
        
           return true;
        }
        catch(Exception ex)
        {
           // Handle exception
        }
        
        return false;
    }
