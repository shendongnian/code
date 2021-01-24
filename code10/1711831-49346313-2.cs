	public class MyClass
	{
		public int Item { get; set; }
		public string Value { get; set; }
		public override string ToString() { return Item.ToString() + "," + Value; }
	}
	
	static public class ExtensionMethods
	{
		static public TValue ValueOrFallback<TKey,TValue>(this Dictionary<TKey,TValue> This, TKey keyToFind, TValue fallbackValue)
		{
			TValue result;
			return This.TryGetValue(keyToFind, out result) ? result : fallbackValue;
		}
		
		static public void MergeInto(this List<MyClass> mergeFrom, List<MyClass> mergeInto)
		{
			var orderBy = new Dictionary<int,int>();
			for (int i=0; i<mergeInto.Count; i++) orderBy.Add(mergeInto[i].Item, i);
			mergeInto.Clear();
			mergeInto.AddRange
			(
				mergeFrom.OrderBy( item => orderBy.ValueOrFallback(item.Item, int.MaxValue) )
			);
		}
	}
						
	public class Program
	{
		public static List<MyClass> A = new List<MyClass>
		{
				new MyClass { Item = 2,Value = "EX2" },
				new MyClass { Item = 3,Value = "ex3" },
				new MyClass { Item = 1,Value = "ex1" }
		};
		public static List<MyClass> B = new List<MyClass>
		{
				new MyClass { Item = 1,Value = "ex1" },
				new MyClass { Item = 2,Value = "ex2" },
				new MyClass { Item = 4,Value = "ex3" },
		};
		
		public static void Main()
		{
			A.MergeInto(B);
			foreach (var b in B) Console.WriteLine(b);
		}
	}
