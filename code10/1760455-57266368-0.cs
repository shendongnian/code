            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserDefinition>()
                .ToTable("UserDefinition");
            //    .HasOne(x => x.Subscription)
            //    .WithMany(x => x.UserDefinitions)
            //    .HasForeignKey(x => x.SubscriptionId);
            modelBuilder.Entity<Subscription>()
                .ToTable("Subscription");
            //    .HasMany(x => x.UserDefinitions)
            //    .WithOne()
            //    .HasForeignKey(x => x.SubscriptionId);
