     public List<IEntity> GetEntities(Common.EntityType entityType)
               {
                   List<IEntity> entities = new List<IEntity>();
        
                   switch (entityType)
                   {
                       case Common.EntityType.Accounts:
                           Entity1 entity1 = new Entity1();
                           entity1.Property1 = "AA";
                           entities.Add(entity1);
        
                           break;
                       case Common.EntityType.Brands:
                           Entity2 entity2 = new Entity2();
                           entity2.Property2 = "AA";
                           entities.Add(entity2);
        
                           break;
                       default:
                           break;
                   }
    
     return entities;
           }
