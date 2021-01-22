    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Edit(Guid id, Department Model)
    {
        using (var context =  new EntityContext())
        {
            try
            {
                Object entity = null;
                IEnumerable<KeyValuePair<string, object>> entityKeyValues =
                    new KeyValuePair<string, object>[] {
                        new KeyValuePair<string, object>("DepartmentID", id) };
        
                // Create the  key for a specific SalesOrderHeader object. 
                EntityKey key = new EntityKey("EntityContext.Deparment",   
                                                                       entityKeyValues);
        
                // Get the object from the context or the persisted store by its key.
                if (context.TryGetObjectByKey(key, out entity))
                {
                   context.ApplyPropertyChanges(key.EntitySetName, Model);
                   context.SaveChanges();
                }
                else
                {
                   // log message if we need
                   //"An object with this key could not be found." 
                }                
            }
            catch (EntitySqlException ex)
            {
               // log message
            }
        }
     }       
