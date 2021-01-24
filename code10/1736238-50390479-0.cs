    // "Microsoft.AspNetCore.Identity.IdentityUserRole<string>"
    ModelBuilder.Entity<UserRole>(E =>
    {
    	E.Property<int>(P => P.UserId)
    		.HasColumnName("AccountId")
    		.IsRequired();
    
    	E.Property<int>("RoleId")
    		.IsRequired();
    
    	E.HasIndex("AccountId")
    		.HasName("IX_RoleMap_AccountId");
    
    	E.HasIndex("RoleId")
    		.HasName("IX_RoleMap_RoleId");
    
    	E.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")    // Argh!
    		.WithMany()
    		.HasForeignKey("RoleId")
    		.OnDelete(DeleteBehavior.Cascade);
    
    	E.HasOne(P => P.Account)
    		.WithMany()
    		.HasForeignKey("AccountId")
    		.OnDelete(DeleteBehavior.Cascade);
    
    	E.ToTable("RoleMap");
    });
