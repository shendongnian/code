    public void TryExecuting(Action work)
    {
        try { work(); }
        catch(Exception ex) { this.ReportFailure(ex); }
    }
