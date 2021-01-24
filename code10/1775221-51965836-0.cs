    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    
    public static class DbContextExtensions
    {
        public static EntityType GetEntityMetadata<TEntity>(this DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException(nameof(dbContext));
    
            var metadataWorkspace = ((IObjectContextAdapter)dbContext)
                .ObjectContext.MetadataWorkspace;
            var itemCollection = ((ObjectItemCollection)metadataWorkspace
                .GetItemCollection(DataSpace.OSpace));
            var entityType = metadataWorkspace.GetItems<EntityType>(DataSpace.OSpace)
                .Where(e => itemCollection.GetClrType(e) == typeof(TEntity)).FirstOrDefault();
    
            if (entityType == null)
                throw new Exception($"No entity mapped to CLR type '{typeof(TEntity)}'.");
    
            return entityType;
        }
    }
