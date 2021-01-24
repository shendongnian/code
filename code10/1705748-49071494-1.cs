    public static void RegisterMaps()
        {
          //get all projects' AutoMapper profiles using reflection
          var assembliesToScan = System.AppDomain.CurrentDomain.GetAssemblies();
          var allTypes = assembliesToScan.SelectMany(a => a.ExportedTypes).ToArray();
    
          var profiles =
              allTypes
                  .Where(t => typeof(Profile).GetTypeInfo().IsAssignableFrom(t.GetTypeInfo()))
                  .Where(t => !t.GetTypeInfo().IsAbstract);
    
          //add each profile to our static AutoMapper
          Mapper.Initialize(cfg =>
          {
            foreach (var profile in profiles)
            {
              cfg.AddProfile(profile);
            }
          });
        }
