    public void processStuff()
    {
        Status returnStatus = Status.Success;
        try
        {
            if (!performStep1())
                return returnStatus = Status.Error;
            if (!performStep2())
                return returnStatus = Status.Warning;
            //.. the rest of the steps ..//
        }
        catch (Exception ex)
        {
            log(ex);
            return returnStatus = Status.Exception;
        }
        finally
        {
            //some necessary cleanup
            FinalProcessing(returnStatus);
        }
    }
