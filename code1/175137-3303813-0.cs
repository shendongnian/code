    Northwnd db = new Northwnd("...");
    try
    {
        // here we attempt to submit changes for the database
        db.SubmitChanges(ConflictMode.ContinueOnConflict);
    }
    
    catch (ChangeConflictException e)
    {
        // we got a change conflict, so we need to process it
        Console.WriteLine(e.Message);
        // There may be many change conflicts (if multiple DB tables were
        // affected, for example), so we need to loop over each
        // conflict and resolve it. 
        foreach (ObjectChangeConflict occ in db.ChangeConflicts)
        {
            // To resolve each conflict, we call
            // ObjectChangeConflict.Resolve, and we pass in OverWriteCurrentValues
            // so that the current values will be overwritten with the values
            // from the database
            occ.Resolve(RefreshMode.OverwriteCurrentValues);
        }
    }
