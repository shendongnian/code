		Dictionary<char, int> someDictionary = new Dictionary<char,int>
		{
			{'A',1},
			{'B',2},
			{'C',3},
			{'D',4}
		};
		
		char[] someCharacterArray = new [] {'A','B','C','E'};
		
		
		var filteredDictionary = someDictionary
			.Join
			(
				someCharacterArray, 
				d => d.Key, 
				c => c, 
				(d,c) => new { Key = d.Key, Value = d.Value}
			)
			.ToDictionary
			(
				k => k.Key, 
				v => v.Value
			);
		
		Console.WriteLine(string.Join("\r\n", filteredDictionary.Select(d => string.Format("{0}={1}", d.Key, d.Value))));
		
