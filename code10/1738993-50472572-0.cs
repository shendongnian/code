    public void UpdateEntitySet<T>(List<object> models, string key) where T : class
    {
        DataContext db = new DataContext();
        List<string> modelIDs = new List<string>();
        foreach(object model in models)
        {
            string modelKey = model.GetType().GetProperty(key).GetValue(model).ToString();
            modelIDs.Add(modelKey);
            T existingEntity = null; 
            foreach (T entity in db.Set<T>())
                if (entity.GetType().GetProperty(key).GetValue(entity).ToString() == modelKey)
                    existingEntity = entity;
            if (existingEntity == null)
            {
                var newEntity = db.Set<T>().Create();
                db.Set<T>().Add(newEntity);
                db.Entry(newEntity).CurrentValues.SetValues(model); //Add new
            }
            else
                db.Entry(existingEntity).CurrentValues.SetValues(model); //Update existing
        }
            
        foreach (T entity in db.Set<T>())
        {
            string entityKey = entity.GetType().GetProperty(key).GetValue(entity).ToString();
            if(!modelIDs.Contains(entityKey))
                db.Entry(entity).State = System.Data.Entity.EntityState.Deleted; //Delete missing
        }
        db.SaveChanges();
    }
