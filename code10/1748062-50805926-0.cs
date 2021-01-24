    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
	    modelBuilder.Entity<Patient>(builder => 
	    {
		    builder
			    .Property(p => p.DateTime)
			    .HasConversion(new DateTimeToStringConverter());
	    });
    }
