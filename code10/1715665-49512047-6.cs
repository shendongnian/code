    public class Property
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class PropertyComposedObject
    {
        public List<Property> Properties { get; set; }
        public Property GetProperty(string name)
        {
            return this.Properties.SingleOrDefault(x => x.Name == name);
        }
    }
    public class Person : PropertyComposedObject
    {
    }
