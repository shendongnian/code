		static List<string> BuildLines(List<string> words, int lineLen)
		{
			List<string> lines = new List<string>();
			string line = string.Empty;
			foreach (string word in words)
			{
				if (string.IsNullOrEmpty(word)) continue;
				if (line.Length + word.Length + 1 <= lineLen)
				{
					line += " " + word;
				}
				else
				{
					lines.Add(line);
					line = word;
				}
			}
			lines.Add(line);
			return lines;
		}
