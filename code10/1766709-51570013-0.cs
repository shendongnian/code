        string text = "[Administrator\",\"Basant Sharma\"]";
		string result = string.Empty;
		var words = text.Split(',');
		for (int i = 0; i < words.Length; i++)
		{
			words[i] = words[i].Replace("\"", "");
			words[i] = words[i].Replace("[", "");
			words[i] = words[i].Replace("]", "");
			if ( i == words.Length - 1)
			{
				result += words[i];
			}
			else
			{
				result += words[i] + ",";
			}
		}
		
		Console.WriteLine(result);
