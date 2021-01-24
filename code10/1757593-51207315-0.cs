    public static class Factory
    {
        static Factory()
        {
            var datasetDerrivedTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(DataSet).IsAssignableFrom(t) &&
                            t != typeof(DataSet));
            foreach (var type in datasetDerrivedTypes)
            {
                System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(type.TypeHandle);  
            }
        }
        public static void Register(Type type, Func<Series, DataSet> constructorDelegate)
        {
            
        }
    }
