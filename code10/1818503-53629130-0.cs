	var comparer = Comparer<long>.Create((x, y) => y.CompareTo(x));
	
    var myDict = new Dictionary<string, SortedDictionary<long, string>
	{
        // Add a SortedDictionary to myDict
		{ "dict1", new SortedDictionary<long, string>>(comparer) 
			{
                // Add a key-value pair to the SortedDictionary
				{ 123, "nestedValue" }
			}
		}
	};
