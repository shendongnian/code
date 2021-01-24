    void Main()
    {
    	var data = JArray.Parse(@"
    	[{
            'Inputs': [	
    			{'Input': 'A B C'},
                {'Input': 'B C E '},
                {'Input': 'C G'},
                {'Input': 'D A F'},
                {'Input': 'E F'},
                {'Input': 'F H'}
            ]
    	}]
    	");
    	var values = data.SelectTokens("..Input").Select(x => x.ToString()).ToArray();
    	var dict = values.ToDictionary(s => s[0], v => v.Substring(2).Where(Char.IsLetter).ToArray());
    	
    	IEnumerable<char> Dependencies(char input)
    	{
    		yield return input;
    		if(dict.TryGetValue(input, out char[] childDepends))
    		{
    			foreach(char result in childDepends.SelectMany(Dependencies))
    			{
    				yield return result;
    			}
    		}
    	}
    	
    	foreach(char s in values.Select(x => x[0]))
    	{
    		Console.Write(s);Console.Write(" ");
    		Console.WriteLine(String.Join(" ", dict[s].SelectMany(Dependencies).Distinct().OrderBy(x => x)));
    	}
    }
