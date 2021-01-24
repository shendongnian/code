    public class TenantDbContext : DbContext
    {
        public TenantDbContext(string connectionString) : base(connectionString)
        {
        }
    // Or
        public TenantDbContext(int tenantId) : base(GetConnectionString(tenantId))
        {
        }
    }
