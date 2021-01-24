    public interface IPropertyComposedObject
    {
        List<Node> Children { get; set; }
    }
    public class Person : IPropertyComposedObject
    {
        public List<Node> Children { get; set; }
    }
    public static class IPropertyComposedObjectExtensions
    {
        public static Node GetNode(this IPropertyComposedObject obj, string name)
        {
            return obj.Children.SingleOrDefault(x => x.Name == name);
        }
    }
