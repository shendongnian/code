    try
    {
      persistentStorage.DataContext.Transaction=persistentStorage.DataContext.Connection.BeginTransaction();
    
      var oldStays = (from stay in persistentStorage.DataContext.Stays 
                    where stays.booking_id == bookingId 
                    select stay);
      persistentStorage.DataContext.Stays.DeleteAllOnSubmit(oldStays);
      persistentStorage.DataContext.SubmitChanges();
    
      // do you select/insert/etc.
      
      if (ok)
        persistentStorage.DataContext.Transaction.Commit();
    }
    finally
    {
      if (persistentStorage.DataContext.Transaction!=null) persistentStorage.DataContext.Transaction.Dispose();
      persistentStorage.DataContext.Transaction=null;
    }
