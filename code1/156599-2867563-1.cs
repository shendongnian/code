    if(serviceIsAlive())
    {
        try
        {
            callService();
        }
        catch(CommunicationException)
        {
            handleFailure();
        }
    }
    else
    {
        handleFailure();
    }
