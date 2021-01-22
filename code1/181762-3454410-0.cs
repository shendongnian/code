    public static IEnumerable GetList(Type type)
            { 
               return (IEnumerable) Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
            }
            
            
    public static List<T> GetList<T>()
           {
               return new List<T>();  
           }
