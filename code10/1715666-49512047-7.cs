    public class Property
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public interface IPropertyComposedObject
    {
        List<Property> Properties { get; set; }
        Property GetProperty(string name);
    }
    public class Person : IPropertyComposedObject
    {
        public List<Property> Properties { get; set; }
        public Property GetProperty(string name)
        {
            return this.Properties.SingleOrDefault(x => x.Name == name);
        }
    }
