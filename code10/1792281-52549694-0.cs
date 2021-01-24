    public virtual DbSet<Article> Article { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    	base.OnModelCreating(modelBuilder);
    
    	modelBuilder.Entity<Article>(b =>
    	{
    		b.Property(e => e.Property1).HasDefaultValue(true);
    		... //Other properties
    	}
