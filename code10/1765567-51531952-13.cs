    public static BinaryTreeNode<string> Solve(BinaryTreeNode<string> node)
    {    
        if(node.Data.Length > 1)
        {
        	var middle = node.Data.Length / 2;
	        var left = node.Data.Substring(0, middle);
    	    var right = node.Data.Substring(middle);    
    	
    		node.Left = Solve(new BinaryTreeNode<string>(left));
	    	node.Right = Solve(new BinaryTreeNode<string>(right));    	
        }
    
        return node;
    }
