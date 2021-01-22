    	var results = ParseExpression("1-7;3:.25:10;1,5,9;4-7");
    	private static List<List<float>> ParseExpression(string expression)
		{
			// "x-y" is the same as "x:1:y" so simplify the expression...
			expression = expression.Replace("-", ":1:");
			var results = new List<List<float>>();
			foreach (var part in expression.Split(';'))
				results.Add(ParseSubExpression(part));
			return results;
		}
		private static List<float> ParseSubExpression(string part)
		{
			var results = new List<float>();
			// If this is a set of numbers...
			if (part.IndexOf(',') != -1)
				// Then add each member of the set...
				foreach (string a in part.Split(','))
					results.AddRange(ParseSubExpression(a));
			// If this is a range that needs to be computed...
			else if (part.IndexOf(":") != -1)
			{
				// Parse out the range parameters...
				var parts = part.Split(':');
				var start = float.Parse(parts[0]);
				var increment = float.Parse(parts[1]);
				var end = float.Parse(parts[2]);
				// Evaluate the range...
				for (var i = start; i <= end; i += increment)
					results.Add(i);
			}
			else
				results.Add(float.Parse(part));
			return results;
		}
