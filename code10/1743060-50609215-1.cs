            string[] lines = File.ReadAllLines(path);
			Dictionary<string, List<string>> collection = new Dictionary<string, List<string>>();
			foreach (var line in lines)
			{
				string[] tokens = line.Split(',');
				if (tokens.Length > 1)
				{
					if (collection.ContainsKey(tokens[0]))
					{
						collection[tokens[0]].Add(tokens[1]);
					}
					else
					{
						collection.Add(tokens[0], new List<string> { tokens[1] });
					}
				}
			}
