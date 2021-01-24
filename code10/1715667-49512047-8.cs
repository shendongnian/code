    public class Property
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public interface IPropertyComposedObject
    {
        List<Property> Properties { get; set; }
    }
    public class Person : IPropertyComposedObject
    {
        public List<Property> Properties { get; set; }
    }
    public static class IPropertyComposedObjectExtensions
    {
        public Property GetProperty(this IPropertyComposedObject obj, string name)
        {
            return obj.Properties.SingleOrDefault(x => x.Name == name);
        }
    }
