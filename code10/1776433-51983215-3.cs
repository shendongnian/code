        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ReplaceService<IRelationalTypeMappingSource, CommonComponents.Data.SqlServerTypeMappingSource>();
            optionsBuilder.UseSqlServer(Data.Configuration.ConnectionString);
        }
