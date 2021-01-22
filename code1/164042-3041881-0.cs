    public static class Extensions
    	{
    		public static string GetPosition(this TreeNode node)
    		{
    			string Result = "";
    			BuildPath(node, ref Result);
    			return Result.TrimStart('.');
    		}
    		private static void BuildPath(TreeNode node,ref string path)
    		{
    			path = "." + node.Index + path;
    			if (node.Parent != null) 
    				BuildPath(node.Parent, ref path);
    		}
    	}
