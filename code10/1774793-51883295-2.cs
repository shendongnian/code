    //This interface allows you to specify a type constraint so AddStuff can use the Id property
	public interface IHasId
	{
		int Id { get; }
	}
	public class User  : IHasId { public int Id { get; set; } }
	public class Item  : IHasId { public int Id { get; set; } }
	public class Store : IHasId { public int Id { get; set; } }
	
	public class Program
	{
		public static Dictionary<int, User> Users = new Dictionary<int, User>();
		public static Dictionary<int, Item> Items = new Dictionary<int, Item>();
		public static Dictionary<int, Store> Stores = new Dictionary<int, Store>();
	
        //This "outer" dictionary will allow AddStuff to look up the right dictionary based on the type.
		public static Dictionary<Type,IDictionary> dictionaries = new Dictionary<Type,IDictionary>
		{
			{ typeof(User ), Users },
			{ typeof(Item ), Items }, 
			{ typeof(Store), Stores}
		};
		
		public static void AddStuff<TValue>(TValue stuffToAdd) where TValue  : IHasId
		{
			IDictionary d = dictionaries[typeof(TValue)] as Dictionary<int, TValue>;
			d.Add(stuffToAdd.Id, stuffToAdd);
		}
		
		public static void Main()
		{
			AddStuff( new User  { Id = 1} );
			AddStuff( new User  { Id = 2} );
			AddStuff( new Item  { Id = 3} );
			AddStuff( new Item  { Id = 4} );
			AddStuff( new Store { Id = 5} );
			AddStuff( new Store { Id = 6} );
			
            Console.WriteLine("Users:  " + string.Join(",", Users.Select( u => u.Value.Id )));
            Console.WriteLine("Items:  " + string.Join(",", Items.Select( i => i.Value.Id )));
            Console.WriteLine("Stores: " + string.Join(",", Stores.Select( s => s.Value.Id )));
		}
	}
