    public abstract class EntitiesContext : DbContext, IEntitiesContext
        {
            /// <summary>
            /// Constructs a new context instance using conventions to create the name of
            /// the database to which a connection will be made. The by-convention name is
            /// the full name (namespace + class name) of the derived context class.  See
            /// the class remarks for how this is used to create a connection. 
            /// </summary>
            protected EntitiesContext() : base()
            {
            }
    
            /// <summary>
            /// Initializes the entity context based on the established user context and the tenant shard map resolver
            /// </summary>
            /// <param name="userContext">The user context</param>
            /// <param name="shardResolver">The Tenant Shard map resolver</param>
            /// <param name="nameorConnectionString">The name or the connection string for the entity</param>
            protected EntitiesContext(MultiTenancy.Core.ProviderContracts.IUserContextDataProvider userContext, ITenantShardResolver shardResolver, string nameorConnectionString)
                : base(shardResolver.GetConnection(userContext.TenantId, nameorConnectionString), true)
            {
    
            }
    }
