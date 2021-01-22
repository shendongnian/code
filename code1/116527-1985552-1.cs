        bool valid = false; 
           if(ValidateRecordIdentifiers() && ValidateTotals() && ValidateRecordCount())
            {
              valid = true;
            }
    
       var statusMessage = (valid) ? LogMessages.StatusMessages.JobValidationPassed : LogMessages.StatusMessages.JobValidationFailed)
       LogLogic.AddEntry(LogLogic.GetEnumDescription(statusMessage));
       
       return valid;
