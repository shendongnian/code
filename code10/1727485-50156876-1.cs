     public void RegisterAllContext(IServiceCollection services)
        {         
            // load assemblies
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
             
             // Get Dal assembly (class assembly want to be injected)
              var dalAssembly = assemblies.FirstOrDefault(assembly => assembly.GetName().Name == "DAL.UOF");
                
    //registre all class with attribut inject 
    // in the service to be injected.
                
        if (dalAssembly != null)
          {
             // Filter All assemblie type 
             // 1- by type is class 
             // 2- by type has CustomAttributes ("InjectableAttribute" in my case)
                		
                
             var assemblieTypesNameContaintContext = from type in dalAssembly.GetTypes()
             where type.IsClass && type.CustomAttributes.Any(
                    a =>{ return a.AttributeType == typeof(InjectableAttribute); })
             select type;
                
          // registre in net core injector service 
             foreach (var typeNameContaintContext in assemblieTypesNameContaintContext.ToList())
           {
              // get full Name assemblie type and
              // add it to the service.
                
                /// typeName == ClassFullName, assemblie Name
                /// Assemblie Name is necessary if the class
                /// in not int the same assemblie (assemblie name : "DAL.UOF" in my case)
                var typeName = typeNameContaintContext.FullName + ",DAL.UOF";
                var type = Type.GetType(typeName);
                if (type != null)
                {
                	services.AddTransient(type, type);
                }
                else
                {
                  Console.WriteLine("type is null");
                }
          }
    }
 
