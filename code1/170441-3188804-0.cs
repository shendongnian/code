	class Program
	{
		static void Main(string[] args)
		{
			IEnumerable<Item> items1 = new List<Item>()
			{
				new Item(){ ClientID = 1, ID = 1},
				new Item(){ ClientID = 2, ID = 2},
				new Item(){ ClientID = 3, ID = 3},
				new Item(){ ClientID = 4, ID = 4},
			};
			Item biggest1 = items1.Aggregate((i1, i2) => i1.ID > i2.ID ? i1 : i2);
			Console.WriteLine(biggest1.ID);
			Console.ReadKey();
		}
	}
	public class Item
	{
		public int ClientID { get; set; }
		public int ID { get; set; }
	}  
