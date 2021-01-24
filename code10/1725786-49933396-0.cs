      private static int GetEnumCountFromClass<T>()
      {
        return typeof(T).GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
             .Count(x => x.IsEnum);
      }
      private static int GetEnumFromAssembly(Assembly assembly, string nameSpace = null)
      {
         assembly = assembly ?? Assembly.GetExecutingAssembly();
         var types = assembly.GetTypes().AsEnumerable();
         if (nameSpace != null)
         {
            types = types.Where(x => x.Namespace == nameSpace);
         }
         return types.Count(x => x.IsEnum);
      }
