    public override int SaveChanges()
    {
        var dateTimeProperties =
            from e in ChangeTracker.Entries()
            where e.State == EntityState.Added
                    || e.State == EntityState.Modified
            from p in e.Properties
            where p.CurrentValue is DateTime
            select p;
        foreach (var property in dateTimeProperties)
        {
            // Strip millisecond
            var value = (DateTime)property.CurrentValue;
            property.CurrentValue = new DateTime(
                value.Year,
                value.Month,
                value.Day,
                value.Hour,
                value.Minute,
                value.Second);
        }
        return base.SaveChanges();
    }
