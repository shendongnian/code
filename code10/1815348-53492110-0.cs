    public class Node
    {
        public Node(params WeightedChild[] weightedChildren)
        {
            this.WeightedChildren = weightedChildren ?? Enumerable.Empty<WeightedChild>();
        }
        IEnumerable<WeightedChild> WeightedChildren { get; }
        public double Evaluate()
        {
            return this.WeightedChildren.Any()
                ? this.WeightedChildren.Select(child => child.Evaluate()).Sum()
                : 1;
        }
    }
    public class WeightedChild
    {
        public WeightedChild(double weight, Node child)
        {
            this.Weight = weight;
            this.Child = child;
        }
        public double Weight { get; }
        Node Child { get; }
        public double Evaluate()
        {
            return this.Child.Evaluate() * this.Weight;
        }
    }
