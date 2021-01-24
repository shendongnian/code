	public class Item
	{
		public int Id { get; set; }
	}
	
	public static void Main()
	{
		var master = (new []{ 1, 2, 3, 4, 5}).Select(x => new Item {Id = x});
		var update = (new []{ 1, 3, 5}).Select(x => new Item {Id = x});
		
		// we need to get all update's ids.
		master = master.Join(update.Select(x => x.Id), o => o.Id, id => id, (o, id) => o);
		
		foreach (var item in master)
		{
			Console.WriteLine(item.Id);
		}
	}
