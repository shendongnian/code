    var entries = this.ChangeTracker.Entries()
        .Where(s => s.State == EntityState.Added || s.State == EntityState.Modified);
    
    foreach (var entry in entries)
    {
        var validationContext = new ValidationContext(entry.Entity);
        Validator.ValidateObject(entry.Entity, validationContext);
    }
