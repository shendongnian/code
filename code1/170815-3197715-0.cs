    try
    {
    }
    catch (Exception caught)
    {
        Type[] types = 
          { 
            typeof(OutOfMemoryException), 
            typeof(NullReferenceException) 
            // Continue adding exceptions to be filtered here.
          };
        if (types.Contains(caught.GetType()))
        {
            // Handle accordingly.
        }
        else
        {
            throw; // Rethrow the exception and preserve stack trace.
        }
    }
