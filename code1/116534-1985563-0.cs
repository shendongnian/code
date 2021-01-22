    public StatusMessages Validate() {
    
      LogMessages.StatusMessages status = LogMessages.StatusMessages.JobValidationFailed;
    
      if( ValidateRecordIdentifiers() && ValidateTotals() && ValidateRecordCount())
        status = LogMessages.StatusMessages.JobValidationPassed;
    
      LogLogic.AddEntry(status.ToString());
    
      return status;
    }
  
