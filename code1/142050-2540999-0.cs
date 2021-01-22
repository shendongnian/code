    Button_Save(object sender, EventArgs e)
    {
        this.Save(ValidationMode.Default);
    }
    Button_HellYesSuppresWarningsAndSave(object sender, EventArgs e)
    {
        this.Save(ValidationMode.SuppressWarnings);
    }
    private Save(ValidationMode mode)
    {
        try
        {
            ServiceLayer.Save(mode);
        }
        catch (ValidationException ex)
        {
            if (ex.ResultType == ValidationResultType.Warnings)
            {
                ShowWarningsAndAskIfSure(ex.Errors);
            }
            else
            {
                ShowErrorsAndTellUserNeedsToFix(ex.Errors);
            }
        }
    }
