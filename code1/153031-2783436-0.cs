    public interface ITopology<TKey> 
    { 
        Dictionary<TKey, INode> Nodes { get; set; }  
    } 
     
    public static class TopologyExtns 
    { 
        public static void AddNode<T>(this ITopology<T> topIf, T key, INode node) 
        { 
            topIf.Nodes.Add(key, node); 
        } 
        public static INode FindNode<T>(this ITopology<T> topIf, T searchObj) 
        { 
            return topIf.Nodes[searchObj]; 
        } 
    } 
    
     
    public class TopologyImp : ITopology<String> 
    { 
    
    public TopologyImp() 
    { 
        Nodes = new Dictionary<String, INode>(); 
    } 
    }
