    foreach (System.Data.Objects.ObjectStateEntry x in MyEntity.ObjectStateManager.GetObjectStateEntries(EntityState.Added)) // or modified for that matter.
    {
       if (x.EntityKey != null)
       {  
          if (x.Entity is MyClass) // look haven't tested this code, merely example and may have typo's
          {
             MyClass tmpObject = (MyClass)x.Entity;
             MyEntity.Refresh(RefreshMode.StoreWins, x);
          }
       }
    }
