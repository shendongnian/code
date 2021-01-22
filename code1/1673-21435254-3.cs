    private Type GetTypeFrom(string valueType)
        {
            var type = Type.GetType(valueType);
            if (type != null)
                return type;
            try
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();                
                //To speed things up, we check first in the already loaded assemblies.
                foreach (var assembly in assemblies)
                {
                    type = assembly.GetType(valueType);
                    if (type != null)
                        break;
                }
                if (type != null)
                    return type;
                var loadedAssemblies = assemblies.ToList();
                foreach (var loadedAssembly in assemblies)
                {
                    foreach (AssemblyName referencedAssemblyName in loadedAssembly.GetReferencedAssemblies())
                    {
                        var found = loadedAssemblies.All(x => x.GetName() != referencedAssemblyName);
                        if (!found)
                        {
                            try
                            {
                                var referencedAssembly = Assembly.Load(referencedAssemblyName);
                                type = referencedAssembly.GetType(valueType);
                                if (type != null)
                                    break;
                                loadedAssemblies.Add(referencedAssembly);
                            }
                            catch
                            {
                                //We will ignore this, because the Type might still be in one of the other Assemblies.
                            }
                        }
                    }
                }                
            }
            catch(Exception exception)
            {
                //throw my custom exception    
            }
            if (type == null)
            {
                //throw my custom exception.
            }
            return type;
        }
