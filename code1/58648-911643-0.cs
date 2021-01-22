    try
    {
        using(IDisposable A = GetDisposable())
        { 
          //Do stuff
        }
    }
    catch
    {
        //Handle exception
        // You do NOT have access to A
    }
    
    
    using(IDisposable A = GetDisposable())  //exception here is uncaught
    {
        try
        {
             //Do stuff
        }
        catch
        {
            //Handle exception
            // You DO have access to A
        }
    }
