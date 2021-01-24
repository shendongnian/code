    public class PropertyComposedObject
    {
        public List<Node> Children { get; set; }
        public Node GetNode(string name)
        {
            return this.Children.SingleOrDefault(x => x.Name == name);
        }
    }
    public class Person : PropertyComposedObject
    {
    }
