    Here's another solution that uses the MetadataWorkspace...
    
    1. Create a base DataAccess class with the following signature.
    
            public class DataAccessBase<TDataEntity> : IDisposable
                where TDataEntity : EntityObject
    
    2. Create a method in DataAccessBase as the following...
    
    
        public TDataEntity GetByKey(object keyId)
                {
                    // Get the entity key name
                    var keyName = EntityContext.MetadataWorkspace
                                    .GetEntityContainer(EntityContext.DefaultContainerName, DataSpace.CSpace)
                                    .BaseEntitySets
                                    .First(x => x.ElementType.Name == typeof(TDataEntity).Name)
                                    .ElementType
                                    .KeyMembers
                                    .Select(key => key.Name)
                                    .FirstOrDefault();
        
                    // Get the Entity Set name
                    var entitySet = (from container in EntityContext.MetadataWorkspace.GetItems<EntityContainer>(DataSpace.CSpace)
                                     from set in container.BaseEntitySets.OfType<EntitySet>()
                                     where set.ElementType.Name == typeof(TDataEntity).Name
                                     select set).FirstOrDefault();
        
        
                    // Create qualified type name for entity
                    string qualifiedTypeName = String.Format("{0}.{1}", EntityContext.DefaultContainerName, entitySet.Name);
        
                    // Create the EntityKey
                    EntityKey entityKey = new EntityKey(qualifiedTypeName, keyName, keyId);
        
                    // Return object by it's entity key
                    return (TDataEntity)EntityContext.GetObjectByKey(entityKey);
                }
