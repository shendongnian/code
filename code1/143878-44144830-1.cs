    public static class TypeExtensions
    {
       public static string CSharpName(this Type type)
       {
           string typeName = type.Name;
    
           if (type.IsGenericType)
           {
               var genArgs = type.GetGenericArguments();
    
               if (genArgs.Count() > 0)
               {
                   typeName = typeName.Substring(0, typeName.Length - 2);
    
                   string args = "";
    
                   foreach (var argType in genArgs)
                   {
                       string argName = argType.Name;
    
                       if (argType.IsGenericType)
                           argName = argType.CSharpName();
    
                       args += argName + ", ";
                   }
    
                   typeName = string.Format("{0}<{1}>", typeName, args.Substring(0, args.Length - 2));
               }
           }
    
           return typeName;
       }		
    }
