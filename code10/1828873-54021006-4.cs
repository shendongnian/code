    class Base
    {
        static readonly IDictionary<string, Base> Registry = 
            new Dictionary<string, Base>();
        protected static Base GetBase(string instanceName)
        {
            lock (Registry)
            {
                if (!Registry.TryGetValue(instanceName, out var newInstance))
                {
                    newInstance = new A(instanceName);
                }
                return newInstance;
            }
        }
    }
