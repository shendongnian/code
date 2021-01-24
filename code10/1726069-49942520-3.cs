    public override int SaveChanges()
    {
        var currentDateTime = DateTime.Now;
        var entries = ChangeTracker.Entries().ToList();
        
        // get a list of all Modified entries which implement the IUpdatable interface
        var updatedEntries = entries.Where(e => e.Entity is IUpdateable)
                .Where(e => e.State == EntityState.Modified)
                .ToList();
        updatedEntries.ForEach(e =>
        {
            ((IUpdateable)e.Entity).UpdatedOn = currentDateTime;
        });
        return base.SaveChanges();
    }
