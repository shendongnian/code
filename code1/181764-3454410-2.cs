     public static IList GetList(Type type)
         { 
           return (IList) Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
         }
      
