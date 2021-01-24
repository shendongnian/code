    public class YourContext
    {
       public override int SaveChanges()
       {
          AuditDeletedEntries();
          base.SaveChanges();
       }
    
       private void AuditDeletedEntries()
       {
    
                ChangeTracker.Entries<yourclassType>().Where(x => x.State == EntityState.Deleted).ToList().Select(x => x.Entity) as List<yourclassType>;
            
          // write changes to your database
       }
    }
