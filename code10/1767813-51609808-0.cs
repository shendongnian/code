    modelBuilder.Entity<MyEntity2>()
    	.HasIndex(p => new { p.Column1, p.Column2, p.Column3, p.Column5 })
    	.HasName("ix_1")
    	.IsUnique();
    
    modelBuilder.Entity<MyEntity2>()
    	.HasIndex(p => new { p.Column1, p.Column2, p.Column4, p.Column5 })
    	.HasName("ix_2")
    	.IsUnique();
    
    modelBuilder.Entity<MyEntity2>()
    	.HasIndex(p => new { p.Column1, p.Column2, p.Column3 })
    	.HasName("ix_3")
    	.IsUnique();
    
    modelBuilder.Entity<MyEntity2>()
    	.HasIndex(p => new { p.Column1, p.Column2, p.Column4 })
    	.HasName("ix_4")
    	.IsUnique();
