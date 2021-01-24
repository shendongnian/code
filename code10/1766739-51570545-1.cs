	public class Item
	{
		public int Id {get;set;}
				
		public override bool Equals(object obj)
		{
    		var item = obj as Item;
    		return item == null ? false : this.Id.Equals(item.Id);
		}
		public override int GetHashCode()
		{
    		return this.Id.GetHashCode();
		}
	}
	
	public static void Main()
	{
		var master = (new []{ 1, 2, 3, 4, 5}).Select(x => new Item {Id = x});
		var update  = (new []{ 1, 3, 5}).Select(x => new Item {Id = x});
		
		// yes all you need is here
		master = master.Intersect(update);
		
		foreach (var item in master)
		{
			Console.WriteLine(item.Id);
		}
	}
