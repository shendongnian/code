    private void InvokeLoadMarriages()
    {
        integrationServicesServiceClient.BeginImportMarriageXML(false, OnEndImportMarriageXML, null);
    }
    private void OnEndImportMarriageXML(IAsyncResult asyncResult)
    {
        view.InvokeDisplayResults(integrationServicesServiceClient.EndImportMarriageXML(asyncResult));
    }
