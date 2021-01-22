    		List<String> entries = new List<string>();
			entries.Add("zero");
			entries.Add("one");
			entries.Add("two");
			Dictionary<int, String> numberedEntries = new Dictionary<int, string>();
			int i = 0;
			entries.ForEach(x => numberedEntries.Add(i++, x));
			foreach (KeyValuePair<int, String> pair in numberedEntries) {
				Console.WriteLine(pair.Key + ": " + pair.Value);
			}
