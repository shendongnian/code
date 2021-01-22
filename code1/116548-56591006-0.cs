public bool Validate()
{            
    bool validDump;
    if(ValidateRecordIdentifiers() && ValidateTotals() && ValidateRecordCount()) {
        LogLogic.AddEntry(LogLogic.GetEnumDescription(
            LogMessages.StatusMessages.JobValidationPassed));
        return true;
    }
    
    LogLogic.AddEntry(LogLogic.GetEnumDescription(
        LogMessages.StatusMessages.JobValidationFailed));
    return false;
}
