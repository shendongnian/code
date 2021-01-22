    public static IEnumerable GetList(Type type)
            { 
               return (IEnumerable) Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
            }
            
