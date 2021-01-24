        modelBuilder.Entity<UserCustomer>()
            .HasKey(t => new {....});
        modelBuilder.Entity<UserCustomer>()
            .HasOne(uc => uc.User)
            .WithMany(u => u.UsersCustomers )
            .HasForeignKey(.. => ....);
        modelBuilder.Entity<UserCustomer >()
            .HasOne(uc => uc.Customer)
            .WithMany(c => c.UsersCustomers)
            .HasForeignKey(.. => .....);
