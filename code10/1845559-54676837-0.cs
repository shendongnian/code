        var names = new List<string>()
		{
			"alice",
			"bob",
			"curt"
		};
		
		var nameVariations = new List<List<string>>();
		foreach (var name in names)
		{
			var variationsOfName = new List<string>();
            for (int i = 0; i < name.Length; i++)
            {
                var newName = name.Substring(0, i) + name.Substring(i + 1);
                if (!variationsOfName.Contains(newName))
				{
                    variationsOfName.Add(newName);
				}
            }
			
			nameVariations.Add(variationsOfName);
		}
		
		return nameVariations.Select(variationsOfName => variationsOfName.ToArray()).ToArray();
