    static void SaveEntity(EntityObject entity)
        {
            using (NorthwindEntities entities = new NorthwindEntities())
            {
                entities.Attach(entity);
                entities.Context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);            
                entities.SaveChanges();
            }
        }
