    public override int SaveChanges()
    {
        var auditables = ChangeTracker.Entries().Where(e =>
            e.State == System.Data.Entity.EntityState.Added || e.State == System.Data.Entity.EntityState.Modified)
            .OfType<IAuditable>();
        var auditor = new Auditor<IAuditable>();
        foreach (var entry in auditables)
        {
            // 1 is userId, I am just hardcoding for brevity
            auditor.ApplyAudit(entry, 1);
        }
        return base.SaveChanges();
    }
