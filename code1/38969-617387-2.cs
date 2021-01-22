		static void Main(string[] args)
		{
			string someName = "two";
			SortedList<string, string> mySortedList = new SortedList<string,string>()
			{
				{"key1", "This is key one"},
				{"key2", "This is key two"},
				{"key3", "This is key three"},
			};
			int namesFound = FindAll(mySortedList.Values, someName).Count ;
			Console.WriteLine(namesFound);
			Console.ReadKey();
		}
		public static IList<String> FindAll(IList<String> items, string item)
		{
			List<String> result = new List<string>();
			foreach (String s in items)
			{
				if (s.Contains(item))
				{
					result.Add(s);
				}
			}
			return result;
		}
