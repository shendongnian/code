    try
    {
        var activeForm = Form.ActiveForm; assumeIsNotNull(activeForm);
        var activeControl = activeForm.ActiveControl; assumeIsNotNull(activeControl);
        var activeControlname = activeControl.Name;
    }
    catch (AssumptionChainFailed)
    {
    }
