    foreach (ValidationResult vr in validationResults)
    {
        if (string.Compare(vr.Tag, "Warning") == 0)
        {
            DisplayWarning(vr.Message);
        }
        else
        {
            DisplayError(vr.Message);
        }
    }
