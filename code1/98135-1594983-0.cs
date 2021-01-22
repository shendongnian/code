        public static class MyClassFactory
        {
            public static MyGenericBaseClass<T> CreateMyClass<T>()
            {
              Activator.CreateInstance(
              Factories.StaticDictionary[typeof(T)]);
            }
        
        }
