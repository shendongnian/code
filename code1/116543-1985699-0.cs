    public bool Validate()
    {
     return LogSuccess(
      new[] {ValidateRecordIdentifiers, ValidateTotals, ValidateRecordCount }
      .All(v=>v()));
    }
    
    private bool LogSuccess(bool success)
    {
     LogLogic.AddEntry(LogLogic.GetEnumDescription(success
       ? LogMessages.StatusMessages.JobValidationPassed
       : LogMessages.StatusMessages.JobValidationFailed
     );
     return success;
    }
