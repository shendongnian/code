    try{
        if (isFileDownloaded)
           //do stuff
        else
           throw new ApplicationException();
    }
    catch(ApplicationException ae)
    {
       // log it application exception here...
    }
    
    catch(Exception ex)
    {
       // log all other exceptions here...
    }
    finally
    {
       // release resources...
    }
