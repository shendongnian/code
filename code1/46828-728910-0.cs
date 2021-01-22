	List<string> data = new List<string> {
		"E", "B", "D", "A", "C", "B", "A", "C"
	};
	var preferences = new Dictionary<string, string> {
		{ "A", " 01" },
		{ "B", " 02" },
		{ "C", " 03" }
	};
	string key;
	IEnumerable<String> orderedData = data.OrderBy(
		item => preferences.TryGetValue(item, out key) ? key : item
	);
