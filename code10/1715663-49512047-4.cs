    public interface IPropertyComposedObject
    {
        List<Node> Children { get; set; }
        Node GetNode(string name);
    }
    public class Person : IPropertyComposedObject
    {
        public List<Node> Children { get; set; }
        public Node GetNode(string name)
        {
            return this.Children.SingleOrDefault(x => x.Name == name);
        }
    }
