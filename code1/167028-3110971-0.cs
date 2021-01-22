    try
    {
        db.SubmitChanges(ConflictMode.ContinueOnConflict);
    }
    
    catch (ChangeConflictException e)
    {
        Console.WriteLine(e.Message);
        foreach (ObjectChangeConflict occ in db.ChangeConflicts)
        {
            //No database values are merged into current.
            occ.Resolve(RefreshMode.KeepCurrentValues);
        }
    }
