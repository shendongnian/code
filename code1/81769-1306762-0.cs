    public bool IsOutOfOffice()
    {
        var outlook = new Microsoft.Office.Interop.Outlook.Application();
        var rdoSession = new Redemption.RDOSession();
        rdoSession.MAPIOBJECT = outlook.Session.MAPIOBJECT;
    
        Redemption.RDOOutOfOfficeAssistant OOFA = 
            (_rdoSession.Stores.DefaultStore as Redemption.RDOExchangeMailboxStore).OutOfOfficeAssistant
    
        return OOFA.OutOfOffice;
    }
