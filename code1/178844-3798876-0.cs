    namespace GenericFactoryPatternTestApp
    {
        public class Factory< T >
        {
            private readonly Dictionary< string, Type > _factoryDictionary = new Dictionary< string, Type >();
     
            public Factory()
            {    
                Type[] types = Assembly.GetAssembly(typeof (T)).GetTypes();
     
                foreach (Type type in types)
                {
                    if (!typeof (T).IsAssignableFrom(type) || type == typeof (T))
                    {
                        // Incorrect type
                        continue;
                    }
     
                    // Add the type
                    _factoryDictionary.Add(type.Name, type);
                }
            }
     
            public T Create< V >(params object[] args)
            {
                return (T) Activator.CreateInstance(_factoryDictionary[typeof (V).Name], args);
            }
        }
    }
