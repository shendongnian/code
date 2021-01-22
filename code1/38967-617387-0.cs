		static void Main(string[] args)
		{
			string someName = "two";
			SortedList<string, string> mySortedList = new SortedList<string,string>()
			{
				{"key1", "This is key one"},
				{"key2", "This is key two"},
				{"key3", "This is key three"},
			};
			int namesFound = mySortedList.Values.Where(i => i.Contains(someName)).Count();
			Console.WriteLine(namesFound);
			Console.ReadKey();
		}
