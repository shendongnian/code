    public bool ValidateAndLog()
    {
        LogMessages.StatusMessages result=Validate();
        LogLogic.AddEntry(LogLogic.GetEnumDescription(result));
        return result==LogMessages.StatusMessages.JobValidationPassed;
    }
    
    private LogMessages.StatusMessages Validate()
    {
        //of course you can combine the next three ifs into one 
        if (!ValidRecordIdentifiers())
            return LogMessages.StatusMessages.JobValidationFailed;
        if (!ValidateTotals())
            return LogMessages.StatusMessages.JobValidationFailed;
        if (!ValidateRecordCount())
            return LogMessages.StatusMessages.JobValidationFailed;
        return LogMessages.StatusMessages.JobValidationPassed;
    }
