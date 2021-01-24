    public void OnMessage(QuickFix.FIX44.ExecutionReport msgReport, SessionID sessionID)
    {
        string clOrdID = msgReport.ClOrdID.getValue();
        ...
        YourProcessing(clOrdID, ...);
    }
