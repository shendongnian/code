    public class Thing
    {
        public int Id;
    	public bool Active = false;
    	public Thing(int id) { Id = id; }
    }
    void Main()
    {
	    var targetIds = new int[] {2, 5, 7 };
    	var things = new Thing[] {new Thing(1), new Thing(2), new Thing(3)};
	
    	foreach (var id in targetIds)
    	{
    		foreach (var thing in things)
    		{
	    		thing.Active = thing.Id == id;
    			Console.WriteLine($"{thing.Id} active: {thing.Active}");
    		}
    	}
    }
