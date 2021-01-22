    var punctuationCharacters = new List<char>();
    		
    		for (int i = char.MinValue; i <= char.MaxValue; i++)
    		{
    			var character = Convert.ToChar(i);
    			
    			if (char.IsPunctuation(character) && !char.IsControl(character))
    			{
    				punctuationCharacters.Add(character);
    			}
    		}
    		
    		var commaSeparatedValueOfPunctuationCharacters = string.Join("", punctuationCharacters);
    		Console.WriteLine(commaSeparatedValueOfPunctuationCharacters);
