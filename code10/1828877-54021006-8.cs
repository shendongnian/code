    public class Base
    {
        static readonly IDictionary<string, Base> Registry = 
            new Dictionary<string, Base>();
        protected static Base GetBase(string instanceName,
                                      Func<Base> creator)
        {
            lock (Registry)
            {
                if (!Registry.TryGetValue(instanceName, out var newInstance))
                {
                    newInstance = creator();
                }   
                return newInstance;
            }
        }
        //...
    }
