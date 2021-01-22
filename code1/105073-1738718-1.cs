    public List<Node> FindNodes(Node source, Func<Node, bool> condition)
    {
    	List<Node> resList = new List<Node>();
    
    	if (source.Nodes != null && source.Nodes.Count > 0)
    	{
    		source.Nodes.ForEach(x =>
    			{
    				resList.AddRange(FindNodes(x, condition));
    				if (condition(x))
    					resList.Add(x);
    			}
    		);
    	}
    
    	return resList;
    }
