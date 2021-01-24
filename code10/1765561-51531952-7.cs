    public static BinaryTreeNode<string> Solve(BinaryTreeNode<string> node)
    {    
        if(node.Data.Length > 1)
        {
        	var middle = node.Data.Length / 2;
	        var left = node.Data.Substring(0, middle);
    	    var right = node.Data.Substring(middle);    
    	
    		node.Left = new BinaryTreeNode<string>(left);
	    	node.Right = new BinaryTreeNode<string>(right);
    	
    		foreach(var child in new[] { node.Left, node.Right })
    			if (child.Data.Length > 1)
    				Solve(child);	
        }
    
        return node;
    }
