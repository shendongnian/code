	protected override void OnModelCreating(ModelBuilder builder)
	{
	    base.OnModelCreating(builder);
		// any guid
		const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
		// any guid, but nothing is against to use the same one
		const string ROLE_ID = ADMIN_ID;
		builder.Entity<IdentityRole>().HasData(new IdentityRole
		{
		    Id = ROLE_ID,
		    Name = "admin",
		    NormalizedName = "admin"
		});
		var hasher = new PasswordHasher<UserEntity>();
		builder.Entity<UserEntity>().HasData(new UserEntity
		{
		    Id = ADMIN_ID,
		    UserName = "admin",
		    NormalizedUserName = "admin",
		    Email = "some-admin-email@nonce.fake",
		    NormalizedEmail = "some-admin-email@nonce.fake",
		    EmailConfirmed = true,
		    PasswordHash = hasher.HashPassword(null, "SOME_ADMIN_PLAIN_PASSWORD"),
		    SecurityStamp = string.Empty
		});
		builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
		{
		    RoleId = ROLE_ID,
		    UserId = ADMIN_ID
		});
	}
