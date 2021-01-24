        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblDepartment>()
                 .ToTable("TblDepartment");
        }
