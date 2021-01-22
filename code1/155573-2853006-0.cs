    try
    {
    _event.someproperty = "that";
    DataContext.SubmitChanges();
    }
    
    catch (ChangeConflictException e)
    {
        foreach (ObjectChangeConflict occ in db.ChangeConflicts)
        {
            // All database values overwrite current values.
            occ.Resolve(RefreshMode.OverwriteCurrentValues);
        }
    }
