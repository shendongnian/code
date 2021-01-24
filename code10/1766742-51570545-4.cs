	public class Item
	{
		public int Id { get; set; }
	}
	
	public static void Main()
	{
        // example
		var master = (new []{ 1, 2, 3, 4, 5}).Select(x => new Item {Id = x});
		var update = (new []{ 1, 3, 5}).Select(x => new Item {Id = x});
		
		// everything happens here.
		var master = master.Intersect(update, new KeyEqualityComparer<Item>(s => s.Id));
		
		foreach (var item in master)
			Console.WriteLine(item.Id);
	}
	
	// Interset doest not know how to compare by property. This will help it.
	public class KeyEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, object> keyExtractor;
        public KeyEqualityComparer(Func<T, object> keyExtractor) => keyExtractor = keyExtractor;
        public bool Equals(T x, T y)  => keyExtractor(x).Equals(this.keyExtractor(y));
        public int GetHashCode(T obj) => keyExtractor(obj).GetHashCode();
    }
