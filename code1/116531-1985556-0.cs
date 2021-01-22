    bool validDump;
    string message;
    if ((!ValidateRecordIdentifiers()) ||
        (!ValidateTotals()) ||
        (!ValidateRecordCount()))
    {
        message = LogLogic.GetEnumDescription(LogMessages.StatusMessages.JobValidationFailed);
    }
    else
    {
        message = LogLogic.GetEnumDescription(LogMessages.StatusMessages.JobValidationPassed);
        validDump = true;
    }
    LogLogic.AddEntry(message);
    return validDump;
