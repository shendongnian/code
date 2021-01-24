    protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.ReplaceService<IModelCacheKeyFactory, DynamicModelCacheKeyFactory>();
        }
