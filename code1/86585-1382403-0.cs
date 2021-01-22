    // main form or secondary form code
    using (var db = new DbAccess())
    {
        if (!db.SaveEmployee(...))
        {
           RecordError(db);
        }
    }
    void RecordError(DbAccess db)
    {
        Logger.logError(db.LastError);
        
        // update the UI
        statusBar.Status = "Error!";
    }
    // code in the data access class
    public bool SaveEmployee(...)
    {
        try { SaveToDb(); return true; }
        catch (Exception ex) { lastError = ex; return false; }
    }
