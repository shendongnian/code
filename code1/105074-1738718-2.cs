    public class Node
    {
    	public Guid Id { get; set; }
    	public DateTime Created { get; set; }
    	public List<Node> Nodes { get; set; }
    
    	public Node()
    	{
    		this.Nodes = new List<Node>();
    	}
    
    	public List<Node> FindNodes(Func<Node, bool> condition)
    	{
    		List<Node> resList = new List<Node>();
    
    		if (this.Nodes != null && this.Nodes.Count > 0)
    		{
    			this.Nodes.ForEach(x =>
    				{
    					resList.AddRange(x.FindNodes(condition));
    					if (condition(x))
    						resList.Add(x);
    				}
    			);
    		}
    
    		return resList;
    	}
    }
