    // Abstract parent class
    public abstract class NodeBase
    {
        public abstract IDictionary<string, NodeBase> Children { get; }
        ...
    }
    
    // Implementing child class
    public class RealNode : NodeBase
    {
        private Dictionary<string, RealNode> containedNodes;
        public override IDictionary<string, NodeBase> Children
        {
            // Using a modification of Bigjim's code to cast the Dictionary:
            return new IDictionary<string, NodeBase>().CastDictionary<string, RealNode, NodeBase>();
        }
        ...
    }
