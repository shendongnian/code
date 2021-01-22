    public class Node
    {
    	public Node()
    	{
    		Children = new List<Node>();
    	}
     
        public static int SumMax { get; set; }
    
    	public List<int> Values { get; set; }
    	
    	public List<Node> Children { get; set; }
    	
    	public void AddChild(int data)
    	{
    		if (values.Sum() + data < SumMax)
    		{
    			Node child = new Node();
    			child.Values = new List<int>(Values);
    			child.Values.Add(data);
    			Children.Add(child);
    			
    			for (int = 1; i<4; i++)
    			{
    				child.AddChild(i);
    			}
    		}
    	}
    	
    	public void FillSequences(List<List<int>> sequences)
    	{
    		if (Values.Count != 0)
    		{
    			sequences.Add(Values);
    		}
    		
    		foreach (Node child in Children)
    		{
    			child.FillSequences(sequences);
    		}
    	}
    }
