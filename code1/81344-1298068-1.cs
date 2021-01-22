    try {
    function1 (...);
    
    }
    catch (Exception ex) {
        //this will not catch all the exception types even though it may look like :)
        HandlingWCFExceptions(ex, taskResult);
    }
    ....
    private void HandlingWCFExceptions(Exception ex, TaskResult result)
    {
        try {
            //This will preserve the original exception status including call stack
            throw;
        } 
        catch (TimeoutException) {
        taskResult.Success = false;
        taskResult.Message = Resources.ServerConnectionBroke;
        }         
        catch (CommunicationException) {
            taskResult.Success = false;
            taskResult.Message = Resources.CommunicationFailed;
        }
        //catch other (WCF) exception types that you can handle safely
        //Any other exception not caught here will bubble up
        ...
    }
