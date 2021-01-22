    public void SubmitKeepChanges()
    {
        try
        {
            this.SubmitChanges(ConflictMode.ContinueOnConflict);
        }
        catch (ChangeConflictException e)
        {
            foreach (ObjectChangeConflict occ in this.ChangeConflicts)
            {
                //Keep current values that have changed, 
    //updates other values with database values
                occ.Resolve(RefreshMode.KeepChanges);
            }
        }
    }
    public void SubmitOverwrite()
    {
        try
        {
            this.SubmitChanges(ConflictMode.ContinueOnConflict);
        }
        catch (ChangeConflictException e)
        {
            foreach (ObjectChangeConflict occ in this.ChangeConflicts)
            {
                // All database values overwrite current values with 
    //values from database
                occ.Resolve(RefreshMode.OverwriteCurrentValues);
            }
        }
    }
    public void SubmitKeepCurrent()
    {
        try
        {
            this.SubmitChanges(ConflictMode.ContinueOnConflict);
        }
        catch (ChangeConflictException e)
        {
            foreach (ObjectChangeConflict occ in this.ChangeConflicts)
            {
                //Swap the original values with the values retrieved from the database. No current value is modified
                occ.Resolve(RefreshMode.KeepCurrentValues);
            }
        }
    }
