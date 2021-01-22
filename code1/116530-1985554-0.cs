    public bool Validate()
    {
        return Validate(ValidateRecordIdentifiers, ValidateTotals, ValidateRecordCount);
    }
    public bool Validate(params Func<bool>[] validators)
    {
        var invalid = validators.FirstOrDefault(v => !v());
        if (invalid != null)
        {
            LogLogic.AddEntry(LogLogic.GetEnumDescription(LogMessages.StatusMessages.JobValidationFailed));
            return false;
        }
        LogLogic.AddEntry(LogLogic.GetEnumDescription(LogMessages.StatusMessages.JobValidationPassed));
        return true;
    }
