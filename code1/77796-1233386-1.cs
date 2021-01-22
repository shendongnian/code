    public void StartService()
    {
        try
        {
           RunSearch();
           SaveMessages();
           DeleteMessages();
        }
        catch(Exception ex)
        {
            //Do Nothing or Log ex
        }
    }
    
    public void RunSearch()
    {
    //No error handler here, as this method cannot recover from exceptions
    
    //RunSearch functionality
    }
