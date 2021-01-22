    try
    {
       sendMessage();
       
       if(message == success)
       {
           doStuff();
       }
       else if(message == failed)
       {
           throw;
       }
    }
    catch(Exception)
    {
        logAndRecover();
    }
