	modelBuilder.Entity<Person>().Property(p => p.ID).UseSqlServerIdentityColumn();
	modelBuilder.Entity<Person>()
		.HasOne(p => p.Image)
		.WithOne()
		.HasForeignKey<Image>(p => p.PersonID);
	modelBuilder.Entity<Product>().Property(p => p.ID).UseSqlServerIdentityColumn();
	modelBuilder.Entity<Product>()
		.HasOne(p => p.Image)
		.WithOne()
		.HasForeignKey<Image>(p => p.ProductID);
	modelBuilder.Entity<Image>().HasKey(p => p.ImgID);
