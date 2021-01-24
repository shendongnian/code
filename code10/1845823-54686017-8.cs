    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasMany(u => u.AssigneeIssues)
                .WithRequired(i => i.Assignee).HasForeignKey(a => a.AssigneeId)
                .WillCascadeOnDelete(false); // <-- cascade delete must be false
            modelBuilder.Entity<User>().HasMany(u => u.ReporterIssues)
                .WithRequired(i => i.Reporter).HasForeignKey(a => a.ReporterId)
                .WillCascadeOnDelete(false); // <-- cascade delete must be false
     }
