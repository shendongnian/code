    public static string EnumToString<T>(object obj)
    {
          string key = String.Empty;
    
          Type type = typeof(T);
    
          key += type.Name + "_" + obj.ToString();
    
          Assembly assembly = Assembly.Load("EnumResources");
    
          string[] resourceNames = assembly.GetManifestResourceNames();
    
          ResourceManager = null;
    
          for(int i = 0; i < resourceNames.Length; i++)
          { 
               if(resourceNames[i].Contains("Enums.resources"))
               {
                    //The substring is necessary cause the ResourceManager is already expecting the '.resurces'
                    rm = new ResourceManager(resourceNames[i].Substring(0, resourceNames[i].Length - 10), assembly);
    
                    return rm.GetString(key);
               }
    
               return obj.ToString();
          }
    
    }
