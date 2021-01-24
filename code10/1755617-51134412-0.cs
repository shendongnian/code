    public class AbpZeroTemplateDbContext : AbpZeroDbContext<Tenant, Role, User, AbpZeroTemplateDbContext>, IAbpPersistedGrantDbContext
    {
         //...
    
         public virtual DbSet<OrganisationUnit> MyOrganizationUnits { get; set; }
    
         //...
    }
