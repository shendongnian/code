    public interface INode<T>
    {
         T Key { get; }
    	 string Name { get; set; }
    	 int ID { get; set; }
    }
    
    public class StringNode : INode<string>
    {
    	public string Key { get { return this.Name; } }
    	public string Name { get; set; }
    	public int ID { get; set; }
    }
    
    public interface ITopology<T> 
    {  
        Dictionary<T, INode<T>> Nodes { get; set; }   
    }  
     
    public static class TopologyExtns  
    {  
        public static void AddNode<T>(this ITopology<T> topIf, INode<T> node )  
        {  
            topIf.Nodes.Add( node.Key, node );  
        }  
        public static INode<T> FindNode<T>(this ITopology<T> topIf, T searchKey )  
        {  
            return topIf.Nodes[searchKey];  
        }  
    }  
     
    public class TopologyImp<T> : ITopology<T>  
    {  
        public Dictionary<T, INode<T>> Nodes { get; set; }  
     
        public TopologyImp()  
        {  
            Nodes = new Dictionary<T, INode<T>>();  
        }  
    }
