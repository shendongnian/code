    public class InterfacesPropertiesMap : Dictionary<Type, PropertyInfo[]>
    {
        public InterfacesPropertiesMap(Type type)
        {
            var interfaces = type.GetInterfaces();
            var properties = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            foreach (var intr in interfaces)
            {
                var map = type.GetInterfaceMap(intr);
                this.Add(intr, properties.Where(p => map.TargetMethods
                                                        .Any(t => t == p.GetGetMethod(true) ||
                                                                  t == p.GetSetMethod(true)))
                                         .Distinct().ToArray());
            }
        }
    }
