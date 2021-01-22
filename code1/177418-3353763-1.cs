    private static List<T> GetInstances<T>()
    {
            return (from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.GetInterfaces().Contains(typeof (T)) && t.GetConstructor(Type.EmptyTypes) != null
                    select (T) Activator.CreateInstance(t)).ToList();
    }
    
