    catch (ChangeConflictException)
    {
        foreach (ObjectChangeConflict occ in DB.ChangeConflicts)
        {
            occ.Resolve(RefreshMode.KeepChanges);
        }
    }
