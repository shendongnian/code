    using System;
    using System.Linq;
    using System.Collections.Generic;
    					
    public class Program
    {
    	class Link
    	{
    		public int id;
    		public int parentId;
    	}
    	
    	
    	static List<Link> GetInput()
    	{
    		var data = new Dictionary<int, int> {{1,0},{2,1},{3,1},{4,3},{5,3},{6,2},{7,1},{8,4}};
    		return data.Select(pair => new Link { id = pair.Key, parentId = pair.Value }).ToList();		
    	}
    	
    	public static void Main()
    	{
    		List<Link> inputData = GetInput();
    		
    		// Scan the nodes and arrange as a lookup (dictionary that maps from parentId to child ids)
    		ILookup<int, int> nodes = inputData.ToLookup( link => link.parentId, link => link.id );
    		
    		// Find root node(s)
    		// (ints that appear as parent IDs, but as child id)
    		IEnumerable<int> roots = inputData
    			.Select( link => link.parentId)
    			.Except( inputData.Select( link => link.id ) );
    		
    		foreach (int rootId in roots)
    		{
    			Display(rootId, nodes, "", 3);
    		}		
    	}
    	
    	static void Display(int id, ILookup<int, int> nodes, string prefix, int padding)
    	{
            // Write node to console
    		Console.Write(prefix);
    		Console.Write(id);
    		for (int i=0; i<padding; i++)
    		{
    			Console.Write(" --");
    		}
    		Console.WriteLine();
    		
            // Recursively write children to console
    		string newPrefix = prefix + id.ToString() + " ";
    		foreach (int childId in nodes[id])
    		{
    			Display( childId, nodes, newPrefix, padding-1 );		
    		}
    	}	
    }
