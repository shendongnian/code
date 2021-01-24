    public abstract class BaseRegistryGetter<T>
    {
        private static readonly IDictionary<string, T> Registry = new Dictionary<string, T>();
        public string Name { get; set; }
        public BaseRegistryGetter(string name)
        {
            this.Name = name;
        }
        public static T GetValue (string instanceName, Func<string, T> creator) {
            lock (Registry)
            {
                if (!Registry.TryGetValue(instanceName, out var newInstance))
                {
                    newInstance = creator(instanceName);
                }
                return newInstance;
            }
        }
    }
