    public class InterfacePropertiesMap : Dictionary<Type, PropertyInfo[]>
    {
        public InterfacePropertiesMap(Type type)
        {
            var interfaces = type.GetInterfaces();
            this.Properties = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            foreach (var intr in interfaces)
            {
                var map = type.GetInterfaceMap(intr);
                this.Add(intr, this.Properties
                                   .Where(p => map.TargetMethods
                                                  .Any(t => t == p.GetGetMethod(true) ||
                                                            t == p.GetSetMethod(true)))
                                   .Distinct().ToArray());
            }
            this.InterfacesProperties =
                   (from value in this.Values
                    from property in value
                    select property).Distinct().ToArray();
            this.NonInterfacesProperties = this.Properties.Except(InterfacesProperties).ToArray();
        }
        public PropertyInfo[] NonInterfacesProperties { get; private set; }
        public PropertyInfo[] InterfacesProperties { get; private set; }
        public PropertyInfo[] Properties { get; private set; }
    }
