    public interface ITopology<T>
    { 
        Dictionary<T, INode> Nodes { get; set; }  
    } 
     
    public static class TopologyExtns 
    { 
        public static void AddNode<T>(this ITopology<T> topIf, INode node, Func<INode,T> keySelector ) 
        { 
            topIf.Nodes.Add( keySelector(node), node ); 
        } 
        public static INode FindNode<T>(this ITopology<T> topIf, T searchKey ) 
        { 
            return topIf.Nodes[searchKey]; 
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
