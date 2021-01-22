var objContext = ((IObjectContextAdapter)this.context).ObjectContext; 
var objSet = objContext.CreateObjectSet<T>();
var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, entityToUpdate); 
Object foundEntity;
var exits = objContext.TryGetObjectByKey(entityKey, out foundEntity);
    if (exits && this.dbset.Local != null && this.dbset.Local.Contains(foundEntity) &&this.dbset.Local.Any())                    
    {
      if (entityKey.EntityKeyValues != null && entityKey.EntityKeyValues.Any())                       
      {       
        DbEntityEntry<T> entry = this.context.Entry(this.dbset.Find(entityKey.EntityKeyValues.FirstOrDefault().Value));
                            entry.CurrentValues.SetValues(entityToUpdate);
       }
    }
    this.context.SaveChanges();
