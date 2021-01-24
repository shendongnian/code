    public interface ITenantShardResolver
        {
            /// <summary>
            /// Gets the tenant specific shard based connection from the metadata
            /// </summary>
            /// <param name="tenantId">The tenant identifier</param>
            /// <param name="connectionStringName">The Connection string name</param>
            /// <returns>
            /// The DbConnection for the specific shard per tenant
            /// <see cref="DbConnection"/> 
            /// </returns>
            DbConnection GetConnection(Guid tenantId, string connectionStringName);
        }
