    UnlockDevice();
    
    try
    {
      DoSomethingWithDevice();
    }
    catch(Exception ex)
    {
      // Do something with the error on DoSomethingWithDevice()
    }
    finally
    {
       try
       {
          LockDevice(); // can fail with an exception
       }
       catch (Exception ex)
       {
           // Do something with the error on LockDevice()
       }
    }
