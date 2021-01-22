    bool webLookupDone = false;
    bool databaseLookupDone = false;
    
    private void FinishedDBLookupCallBack()
    {
        databaseLookupDone = true;
        if(webLookupDone)
        {
            FinishMethod();
        }
    }
    
    private void FinishedWebLookupCallBack()
    {
        webLookupDone = true;
        if(databaseLookupDone)
        {
            FinishMethod();
        }
    }
