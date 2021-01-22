    public interface ITopology<T>
    {
        Dictionary<T, INode> Nodes { get; set; } 
    }
    
    public static class TopologyExtns
    {
        public static void AddNode(this ITopology<string> topIf, INode node)
        {
            topIf.Nodes.Add(node.Name, node);
        }
        public static INode FindNode(this ITopology<string> topIf, string searchStr)
        {
            return topIf.Nodes[searchStr];
        }
    }
    
    public class TopologyImp<T> : ITopology<T>
    {
        public Dictionary<T, INode> Nodes { get; set; }
    
        public TopologyImp()
        {
            Nodes = new Dictionary<T, INode>();
        }
    }
