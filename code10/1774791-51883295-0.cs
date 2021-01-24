	public interface IHasId
	{
		int Id { get; }
	}
	public class User : IHasId { public int Id { get; set; } }
	public class Item  : IHasId { public int Id { get; set; } }
	public class Store  : IHasId { public int Id { get; set; } }
	
	public class Program
	{
		public static Dictionary<int, User> Users = new Dictionary<int, User>();
		public static Dictionary<int, Item> Items = new Dictionary<int, Item>();
		public static Dictionary<int, Store> Stores = new Dictionary<int, Store>();
	
		public static Dictionary<Type,IDictionary> dictionaries = new Dictionary<Type,IDictionary>
		{
			{ typeof(User), Users},
			{ typeof(Item), Items}, 
			{ typeof(Store), Stores}
		};
		
		public static void AddStuff<TValue>(TValue stuffToAdd) where TValue  : IHasId
		{
			IDictionary d = dictionaries[typeof(TValue)] as Dictionary<int, TValue>;
			d.Add(stuffToAdd.Id, stuffToAdd);
		}
		
		public static void Main()
		{
			AddStuff( new User { Id = 1 } );
			AddStuff( new Item { Id = 2 } );
			AddStuff( new Store{ Id = 3 } );
		}
	}
