    modelBuilder.Entity<MyEntity2>()
    	.Property(e => e.Column1)
    	.HasColumnAnnotation(
    		IndexAnnotation.AnnotationName,
    		new IndexAnnotation(new[]
    		{
    			new IndexAttribute("ix_3", 1) { IsUnique = true },
    			new IndexAttribute("ix_4", 1) { IsUnique = true },
    			new IndexAttribute("ix_2", 1) { IsUnique = true },
    			new IndexAttribute("ix_1", 1) { IsUnique = true }
    		}));
    
    modelBuilder.Entity<MyEntity2>()
    	.Property(e => e.Column2)
    	.HasColumnAnnotation(
    		IndexAnnotation.AnnotationName,
    		new IndexAnnotation(new[]
    		{
    			new IndexAttribute("ix_3", 2) { IsUnique = true },
    			new IndexAttribute("ix_4", 2) { IsUnique = true },
    			new IndexAttribute("ix_2", 2) { IsUnique = true },
    			new IndexAttribute("ix_1", 2) { IsUnique = true }
    		}));
    
    modelBuilder.Entity<MyEntity2>()
    	.Property(e => e.Column3)
    	.HasColumnAnnotation(
    		IndexAnnotation.AnnotationName,
    		new IndexAnnotation(new[]
    		{
    			new IndexAttribute("ix_3", 3) { IsUnique = true },
    			new IndexAttribute("ix_1", 3) { IsUnique = true }
    		}));
    
    modelBuilder.Entity<MyEntity2>()
    	.Property(e => e.Column4)
    	.HasColumnAnnotation(
    		IndexAnnotation.AnnotationName,
    		new IndexAnnotation(new[]
    		{
    			new IndexAttribute("ix_4", 3) { IsUnique = true },
    			new IndexAttribute("ix_2", 3) { IsUnique = true },
    		}));
    		
    modelBuilder.Entity<MyEntity2>()
    	.Property(e => e.Column5)
    	.HasColumnAnnotation(
    		IndexAnnotation.AnnotationName,
    		new IndexAnnotation(new[]
    		{
    			new IndexAttribute("ix_2", 4) { IsUnique = true },
    			new IndexAttribute("ix_1", 4) { IsUnique = true },
    		}));
