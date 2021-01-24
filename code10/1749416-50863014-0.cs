    builder.Entity<User>().OwnsOne(e => e.EmailPermissions).HasData(
        new
        {
            UserId = "37846734-172e-4149-8cec-6f43d1eb3f60",
            // other properties ...
        }
    );
