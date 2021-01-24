    public class TenantDbContextFactory : IDbContextFactory<TenantDbContext, int>
    {
        public TenantDbContext Create(int tenantId)
        {
            var connectionString = GetConnectionString(tenantId);
            return new TenantDbContext(connectionString);
        }
        // ... rest of factory
    }
    public interface IDbContextFactory<TContext, TKey> where TContext :DbContext
    {
         TContext Create(TKey key);
    }
