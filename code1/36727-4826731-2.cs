    public partial class NorthwindEntities
    {
        partial void OnContextCreated()
        {
            // Adding validation support when saving.
            this.SavingChanges += (sender, e) =>
            {
                // Throws an exception when invalid.
                EntityValidator.Validate(
                    this.GetChangedEntities());
            }
        }
     
        private IEnumerable<object> GetChangedEntities()
        {
            const EntityState AddedAndModified =
                EntityState.Added | EntityState.Modified;
       
            var entries = this.ObjectStateManager
                .GetObjectStateEntries(AddedAndModified);
           
            return
                from entry in entries
                where entry.Entity != null
                select entry.Entity;
        }
    }
