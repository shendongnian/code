public class TenantsDbContext : DbContext
{
    // ....
    public void AddSampleData()
    {
        // add samples only if there's no record.
        if(Tenants.Count()==0){
            Tenants.Add(new Tenant
            {
                Id = MultitenantDbContext.Tenant1Id,
                Name = "Imaginary corp.",
                HostName = "imaginary.example.com"
            });
            Tenants.Add(new Tenant
            {
                Id = MultitenantDbContext.Tenant2Id,
                Name = "The Very Big corp.",
                HostName = "big.example.com"
            });
            SaveChanges();
        }
    }
}
> Also my 2nd questions, I don't understand why this DatabaseTenantProvider class get executed in add-migration init on the MultiTenantDbContext ?!?!
That's because the `DatabaseTenantProvider` is registered as an implementation of `ITenantProvider` service, 
    services.AddTransient<ITenantProvider, DatabaseTenantProvider>()
which is required by the `MultitenantDbContext` class:
    public class MultitenantDbContext : DbContext
    {
        //...
        // note we inject the `ITenantProvider` service here!
        public MultitenantDbContext(DbContextOptions<MultitenantDbContext> options,
                                    ITenantProvider tenantProvider) : base(options)
        {
            _tenantProvider = tenantProvider;
        }
    }
When EF Core invokes the `MultitenantDbContext.OnModelCreating()` methods , it will then invoke the `ITenantProvider` service (i.e. the `DatabaseTenantProvider` class) to get the ID. 
