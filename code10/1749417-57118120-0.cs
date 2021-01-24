    private void SeedUser(ModelBuilder builder)
    {
        builder.Entity<User>(b =>
        {
            b.HasData(new User
            {
                Id = "37846734-172e-4149-8cec-6f43d1eb3f60",
                Email = "foo@foo.foo",
                UserName = "foo@foo.foo",
                // more properties of User
            });
            b.OwnsOne(e => e.EmailPermissions).HasData(new 
            {
                    UserId = "37846734-172e-4149-8cec-6f43d1eb3f60",
                    Newsletter = true,
                    PromotionalOffers = true,
                    PrestationReminders = true,
                    PrestationOffers = true
            });
        });
    }
   
    
