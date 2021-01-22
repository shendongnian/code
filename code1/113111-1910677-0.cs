    bool success = false;
    while (!success)
    {
      try
      {
        database.SubmitChanges();
        success = true;
      }
      catch (ChangeConflictException)
      {
        database.ChangeConflicts.ResolveAll(RefreshMode.KeepChanges);
      }
    }
