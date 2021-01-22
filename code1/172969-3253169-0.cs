    protected virtual void Update(T entity, Expression<Func<T, bool>> query)
    {
       using (DC db = new DC())
       {
        object propertyValue = null;
            T entityFromDB = db.GetTable<T>().Where(query).SingleOrDefault();
              if (null == entityFromDB)
                 throw new NullReferenceException("Query Supplied to " + 
                       "Get entity from DB is invalid, NULL value returned");
            PropertyInfo[] properties = entityFromDB.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
               propertyValue = null;
                    if (null != property.GetSetMethod())
                    {
                      PropertyInfo entityProperty = 
                            entity.GetType().GetProperty(property.Name);
                        if (entityProperty.PropertyType.BaseType == 
                            Type.GetType("System.ValueType")|| 
                            entityProperty.PropertyType == 
                            Type.GetType("System.String"))
    
                          propertyValue = 
                           entity.GetType().GetProperty(property.Name).GetValue(entity, null);
                        if (null != propertyValue)
                            property.SetValue(entityFromDB, propertyValue, null);
                    }
                }
                db.SubmitChanges();
            }
        }
