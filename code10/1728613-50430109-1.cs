    public class MyDbContext: DbContext
    {
    	...
    	
    	public DbSet<Translation> Translations { get; set; }
    	public DbSet<SomeModel> SomeModels { get; set; }
    	public DbSet<AnotherModel> AnotherModels { get; set; }
    	
    	protected override void OnModelCreating(ModelBuilder modelBuilder)
    	{
            ...
    		modelBuilder.Entity<Translation>().HasKey(e => e.Id);
    
    		var baseModelTypes = typeof(BaseModel).Assembly.GetExportedTypes()
    			.Where(t => typeof(BaseModel).IsAssignableFrom(t) && t != typeof(BaseModel)).ToList();
    
    		foreach (var type in baseModelTypes)
    		{
    			modelBuilder.Entity<Translation>().HasOne(type).WithMany(nameof(BaseModel.Translations)).HasForeignKey(nameof(Translation.ModelId));
    
    			modelBuilder.Entity(type).Ignore(nameof(BaseModel.ModelType));
    			modelBuilder.Entity(type).Ignore(nameof(BaseModel.ModelTypeTranslations));
    			modelBuilder.Entity(type).HasKey(nameof(BaseModel.Id));
    		}
    	}
    }
