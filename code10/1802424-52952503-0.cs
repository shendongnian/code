    void Main()
    {
    	var nodes = new List<NestedNode>();
    	
    	var isActive = nodes.Any(n => n.AnyActive("url"));
    }
    
    public class NestedNode
    {
    	public NestedNode()
    	{
    		Children = Enumerable.Empty<NestedNode>();
    	}
    	public string Url { get; set; }
    	public IEnumerable<NestedNode> Children { get; set; }
    	
    	public bool AnyActive(string url){ return Url==url || Children.Any(c => c.AnyActive(url));}
    }
