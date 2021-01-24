    public override int SaveChanges()
    {
        var auditables = ChangeTracker.Entries().Where(e =>
            e.State == System.Data.Entity.EntityState.Added || e.State == System.Data.Entity.EntityState.Modified)
            .OfType<IAuditable>();
        var auditor = new Auditor<IAuditable>();
        foreach (var entry in auditables)
        {
            auditor.ApplyAudit(entry);
        }
        return base.SaveChanges();
    }
