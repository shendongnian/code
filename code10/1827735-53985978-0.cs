    public Dictionary<Type, List<object>> FindDbContextsInAssemblies()
    {
       var dbContexts = new Dictionary<Type, List<object>>();
    
       var assemblies = AppDomain.CurrentDomain.GetAssemblies();
       foreach(var assembly in assemblies)
       {
          foreach(var type in assembly.GetTypes())
          {
             if(type.IsSubclassOf(typeof(DbContext)))
             {
                // Instantiate DbContext:
                var context = type.GetConstructor(Array.Empty<Type>()).Invoke(Array.Empty<object>());
                
                // Find method to get entities:
                var model = type.GetProperty("Model");
                var searchMethod = model.PropertyType.GetMethod("GetEntityTypes");
                
                // Get registered entities:
                var entities = searchMethod.Invoke(model.GetValue(context, null), null) as List<object>;
                dbContexts[type] = entities;
             }
          }
       }
       return dbContexts;
    }
