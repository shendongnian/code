    try {
    function1 (...);
    
    }
    catch (Exception ex) {
        HandlingWCFExceptions(ex, taskResult);
    }
    ....
    private void HandlingWCFExceptions(Exception ex, TaskResult result)
    {
        try {
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
        ...
    }
