    // "Microsoft.AspNetCore.Identity.IdentityUserRole<string>"
    ModelBuilder.Entity<UserRole>(E =>
    {
    	E.Property(P => P.UserId)
    		.HasColumnName("AccountId")
    		.IsRequired();
    
    	E.Property(P => P.RoleId)
    		.IsRequired();
    
    	E.HasIndex(P => P.AccountId)
    		.HasName("IX_RoleMap_AccountId");
    
    	E.HasIndex(P => P.RoleId)
    		.HasName("IX_RoleMap_RoleId");
    
    	E.HasOne(P => P.Role)            // 'UserRole' does not contain a definition for 'Role'
    		.WithMany()
    		.HasForeignKey(P => P.RoleId)
    		.OnDelete(DeleteBehavior.Cascade);
    
    	E.HasOne(P => P.Account)
    		.WithMany()
    		.HasForeignKey(P => P.AccountId)
    		.OnDelete(DeleteBehavior.Cascade);
    
    	E.ToTable("RoleMap");
    });
