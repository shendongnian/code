    class Income
    {
        public int InternalId { get; set; }
        public string Name { get; set; }
    }
	var dictionary = new Dictionary<int,bool?>
	{
		{1, false},
		{2, true},
		{3, null},
	};
	
	var incomeCollection = new List<Income>
	{
		new Income { InternalId = 1, Name = "A" },
		new Income { InternalId = 2, Name = "B" },
		new Income { InternalId = 3, Name = "C" },
		new Income { InternalId = 4, Name = "D" },
	};
	
	var result = incomeCollection.Where(x =>
        dictionary.TryGetValue(x.InternalId, out var status) && status == true)
        .Select(h=> new {Item = h.Name});
