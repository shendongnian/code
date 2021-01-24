    modelBuilder.Entity<Tenant>().HasData(new []{ 
       new Tenant {
          TenantID = 1, // Must be != 0
          Name = "SystemTenant",
       }
    });
