    using (var identityContext = new IdentityDatabase(identityOptions))
    {
        using (var transaction = identityContext.Database.BeginTransaction())
        {
            Console.WriteLine("Inserting AuthClients");
            identityContext.AuthClients.AddRange(identityAuthClients);
            identityContext.SaveChanges();
    
            Console.WriteLine("Inserting ClientGroups");
            identityContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.ClientGroups ON");
            identityContext.ClientGroups.AddRange(identityClientGroups);
            identityContext.SaveChanges();
            identityContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.ClientGroups OFF");
    
            Console.WriteLine("Inserting Clients");
            identityContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Clients ON");
            identityContext.Clients.AddRange(identityclients);
            identityContext.SaveChanges();
            identityContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Clients OFF");
    
            Console.WriteLine("Inserting ClientGroupAssociations");
            identityContext.ClientGroupAssociations.AddRange(identityClientGroupAssociations);
            identityContext.SaveChanges();
    
            Console.WriteLine("Inserting Users");
            identityContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Users ON");
            identityContext.Users.AddRange(identityUsers);
            identityContext.SaveChanges();
            identityContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Users OFF");
    
            Console.WriteLine("Inserting Roles");
            identityContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Roles ON");
            identityContext.Roles.AddRange(identityRoles);
            identityContext.SaveChanges();
            identityContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Roles OFF");
    
            Console.WriteLine("Inserting UserRoles");
            identityContext.UserRoles.AddRange(identityUserRoles);
            identityContext.SaveChanges();
    
            Console.WriteLine("Inserting ModulePermissions");
            identityContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.ModulePermissions ON");
            identityContext.ModulePermissions.AddRange(identityModulePermissions);
            identityContext.SaveChanges();
            identityContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.ModulePermissions OFF");
    
            Console.WriteLine("Commiting transaction");
            transaction.Commit();
        }
    }
