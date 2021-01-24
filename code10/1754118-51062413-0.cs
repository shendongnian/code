	using System;
	using System.Collections.ObjectModel;
						
	public class Program
	{
		public static void Main()
		{
			var items = new []
			{
				new Item{ Id = 1, Value = "Hello" },
				new Item{ Id = 2, Value = "World!" },
			};
			
			var collection = new ObservableCollection<Item>(items);
			
			for(int i = 0; i < 10; i++)
			{
				var item = collection[i % collection.Count];
				var message = String.Format("{0}: {1}", item.Id, item.Value);
				Console.WriteLine(message);
			}
		}
	}
	public class Item
	{
		public int Id { get; set; }
		public string Value { get; set; }
	}
