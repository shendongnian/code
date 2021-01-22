    CatchCommonExceptions(() => function1(...));
    private void CatchCommonExceptions(Action action)
    {
        try
        {
        }
        catch (TimeoutException) {
            taskResult.Success = false;
            taskResult.Message = Resources.ServerConnectionBroke;
        }
        catch (CommunicationException)
        {
            taskResult.Success = false;
            taskResult.Message = Resources.CommunicationFailed;
        }
    }
