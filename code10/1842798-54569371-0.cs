    DbContext db;
    var assemblyName = "MyProject.MyEntities";
    var entityName = "FooEntity";
    long theEntityId = 1337;
    
    var assembly = AppDomain.CurrentDomain.GetAssemblies()
                       .SingleOrDefault(a => a.GetName().Name == assemblyName);
    var entityType = assembly.GetTypes()
                       .FirstOrDefault(t => t.Name == entityName);
    var dbSet = db.Set(entityType);
    var singleEntity = dbSet.Find(theEntityId);
    var allEntities = dbSet.ToArray();
