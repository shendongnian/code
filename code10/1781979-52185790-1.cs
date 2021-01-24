    public partial class YourContextModel : DbContext
	{
		public FizContextModel()
			: base("name=YourDataBaseConnectionString")
		{
		}
		public virtual DbSet<webpages_Membership> webpages_Membership { get; set; }
		public virtual DbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
		public virtual DbSet<webpages_Roles> webpages_Roles { get; set; }
		public virtual DbSet<webpages_Users> webpages_Users { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<webpages_Users>()
				.HasOptional(e => e.webpages_Membership)
				.WithRequired(e => e.webpages_Users);
			modelBuilder.Entity<webpages_Users>()
				.HasMany(e => e.webpages_Roles)
				.WithMany(e => e.webpages_Users)
				.Map(m => m.ToTable("webpages_UsersInRoles").MapLeftKey("UserId").MapRightKey("RoleId"));
		}
	}
 
