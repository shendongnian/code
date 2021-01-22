    public class InterfacesPropertiesMap
    {
        private readonly Dictionary<Type, PropertyInfo[]> map;
        public InterfacesPropertiesMap(Type type)
        {
            this.Interfaces = type.GetInterfaces();
            var properties = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            this.map = new Dictionary<Type, PropertyInfo[]>(this.Interfaces.Length);
            foreach (var intr in this.Interfaces)
            {
                var interfaceMap = type.GetInterfaceMap(intr);
                this.map.Add(intr, properties.Where(p => interfaceMap.TargetMethods
                                                        .Any(t => t == p.GetGetMethod(true) ||
                                                                  t == p.GetSetMethod(true)))
                                             .Distinct().ToArray());
            }
        }
        public Type[] Interfaces { get; private set; }
        public PropertyInfo[] this[Type interfaceType]
        {
            get { return this.map[interfaceType]; }
        }
    }
