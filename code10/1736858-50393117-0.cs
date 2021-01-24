    ModelBuilder.Entity<Role>(E =>
    {
    	E.Property(P => P.Id)
    		.HasColumnName("RoleId")
    		.ValueGeneratedOnAdd();
    
    	E.Property(P => P.ConcurrencyStamp)
    		.HasMaxLength(512)
    		.IsConcurrencyToken();
    
    	E.Property(P => P.Name)
    		.HasMaxLength(512);
    
    	E.Property(P => P.NormalisedName)
    		.HasMaxLength(512);
    
    	E.HasKey(P => P.Id);
    
    	E.HasIndex(P => P.NormalisedName)
    		.IsUnique()
    		.HasName("IX_Roles_NormalisedName");
    
    	E.ToTable("Roles");
    });
