	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		// Table renames
		modelBuilder.Entity<Criteria>().ToTable("Criteria");
		modelBuilder.Entity<IdentityRole>().ToTable("Roles");
		modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
		modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
		modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
		
		// One to One
		modelBuilder.Entity<Attribute>().HasOptional(m => m.Type).WithRequired(m => m.Attribute).WillCascadeOnDelete(false);
		modelBuilder.Entity<Attribute>().HasOptional(m => m.Operation).WithRequired(m => m.Attribute).WillCascadeOnDelete(false);
		modelBuilder.Entity<Answer>().HasOptional(m => m.Scenario).WithRequired(m => m.Answer).WillCascadeOnDelete(false);
		modelBuilder.Entity<Answer>().HasOptional(m => m.Criteria).WithMany().HasForeignKey(m => m.CriteriaId).WillCascadeOnDelete(false);
		// One to Many  
		modelBuilder.Entity<Criteria>().HasMany(m => m.Attributes).WithRequired().HasForeignKey(m => m.CriteriaId).WillCascadeOnDelete(true);
		modelBuilder.Entity<IdentityRole>().HasMany(m => m.Users).WithRequired().HasForeignKey(m => m.RoleId).WillCascadeOnDelete(false);
		modelBuilder.Entity<Organisation>().HasMany(m => m.Feeds).WithRequired().HasForeignKey(m => m.OrganisationId).WillCascadeOnDelete(true);
		modelBuilder.Entity<Organisation>().HasMany(m => m.Users).WithRequired().HasForeignKey(m => m.OrganisationId).WillCascadeOnDelete(true);
		modelBuilder.Entity<Question>().HasMany(m => m.Answers).WithRequired(m => m.Question).HasForeignKey(m => m.QuestionId).WillCascadeOnDelete(true);
		modelBuilder.Entity<Category>().HasMany(m => m.Sortations).WithRequired().HasForeignKey(m => m.CategoryId).WillCascadeOnDelete(true);
		modelBuilder.Entity<Category>().HasMany(m => m.Criteria).WithRequired().HasForeignKey(m => m.CategoryId).WillCascadeOnDelete(true);
		modelBuilder.Entity<Category>().HasMany(m => m.Feeds).WithRequired().HasForeignKey(m => m.CategoryId).WillCascadeOnDelete(true);
		modelBuilder.Entity<Category>().HasMany(m => m.Questions).WithOptional().HasForeignKey(m => m.CategoryId).WillCascadeOnDelete(true);
		modelBuilder.Entity<Category>().HasMany(m => m.Quotes).WithRequired().HasForeignKey(m => m.CategoryId).WillCascadeOnDelete(true);
		modelBuilder.Entity<User>().HasMany(m => m.Searches).WithRequired().HasForeignKey(m => m.UserId).WillCascadeOnDelete(true);
		modelBuilder.Entity<User>().HasMany(m => m.Charges).WithRequired().HasForeignKey(m => m.UserId).WillCascadeOnDelete(true);
		
		modelBuilder.Entity<Attribute>().HasMany(m => m.Formulas).WithRequired().HasForeignKey(m => m.AttributeId).WillCascadeOnDelete(true);
		modelBuilder.Entity<Answer>().HasMany(m => m.Formulas).WithRequired().HasForeignKey(m => m.AnswerId).WillCascadeOnDelete(true);
		// Create our primary keys
		modelBuilder.Entity<IdentityUserLogin>().HasKey(m => m.UserId);
		modelBuilder.Entity<IdentityRole>().HasKey(m => m.Id);
		modelBuilder.Entity<IdentityUserRole>().HasKey(m => new {m.RoleId, m.UserId});
		modelBuilder.Entity<AttributeOperation>().HasKey(m => m.AttributeId);
		modelBuilder.Entity<AttributeType>().HasKey(m => m.AttributeId);
		modelBuilder.Entity<Scenario>().HasKey(m => m.AnswerId);
	}
