    protected override ActivityExecutionStatus Execute(ActivityExecutionContext provider)
    {
        try
        {
            // do work
            // ...
        }
        catch (Exception e)
        {
            // log the error to the history list
            // ...
            throw;
        }
    
        return ActivityExecutionStatus.Closed;
    }
