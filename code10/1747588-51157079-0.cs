    builder.Entity<User>().HasData(new User
            {
                Id = 2147483646,
                AccessFailedCount = 0,
                PasswordHash = "SomePasswordHashKnownToYou",
                LockoutEnabled = true,
                FirstName = "AdminFName",
                LastName = "AdminLName",
                UserName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                InitialPaymentCompleted = true,
                MaxUnbalancedTech = 1,
                UniqueStamp = "2a1a39ef-ccc0-459d-aa9a-eec077bfdd22",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                NormalizedUserName = "ADMIN",
                TermsOfServiceAccepted = true,
                TermsOfServiceAcceptedTimestamp = new DateTime(2018, 3, 24, 7, 42, 35, 10, DateTimeKind.Utc),
                SecurityStamp = "ce907fd5-ccb4-4e96-a7ea-45712a14f5ef",
                ConcurrencyStamp = "32fe9448-0c6c-43b2-b605-802c19c333a6",
                CreatedTime = new DateTime(2018, 3, 24, 7, 42, 35, 10, DateTimeKind.Utc),
                LastModified = new DateTime(2018, 3, 24, 7, 42, 35, 10, DateTimeKind.Utc)
            });
    builder.Entity<UserRoles>().HasData(new UserRoles() { RoleId = 2147483645, UserId = 2147483646 });
