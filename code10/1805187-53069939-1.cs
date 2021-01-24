    public static void Main()
	{
		List<MyItem[]> MyItems = new List<MyItem[]>()
		{
			new MyItem[] { new MyItem("Item1") },
			new MyItem[] { new MyItem("Item1"), new MyItem("Item2") },
			new MyItem[] { new MyItem("Item3") },
			new MyItem[] { new MyItem("Item1"), new MyItem("Item3"), new MyItem("Item2") },
			new MyItem[] { new MyItem("Item3"), new MyItem("Item1") },
			new MyItem[] { new MyItem("Item2"), new MyItem("Item1") }
		};
		Dictionary<Tuple<string, string>, int> results = new Dictionary<Tuple<string, string>, int>();		
		foreach (MyItem[] arr in MyItems)
		{
			// Iterate through the items in the array. Then, iterate through the items after that item in the array to get all combinations.
			for (int i = 0; i < arr.Length; i++)
			{
				string s1 = arr[i].ItemName;
				for (int j = i + 1; j < arr.Length; j++)
				{
					string s2 = arr[j].ItemName;
					// Order the Tuple so that (Item1, Item2) is the same as (Item2, Item1).					
					Tuple<string, string> t = new Tuple<string, string>(s1, s2);
					if (string.Compare(s1, s2) > 0)
					{
						t = new Tuple<string, string>(s2, s1);	
					}
					if (results.ContainsKey(t))
					{
						results[t]++;
					}
					else
					{
						results[t] = 1;
					}
				}
			}
		}
		// And here are your results.
        // You can always use Linq to sort the dictionary by values.
		foreach (var v in results)
		{
			Console.WriteLine(v.Key.ToString() + " = " + v.Value.ToString());
		}
	}
...
    
    public class MyItem
    {
        public string ItemName { get; set; }
    	public MyItem(string ItemName)
    	{
    		this.ItemName = ItemName;	
    	}
    }
