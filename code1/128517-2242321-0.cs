		static string Rewrite(string input)
		{
			StringBuilder builder = new StringBuilder();
			var stack = new Stack<char>();
			string[] lines = input.Split('\n');
			foreach (var line in lines)
			{
				var s = line.Trim();
				if (s.Contains("{") || s.Contains("="))
				{
					stack.Push(s[0]);
				}
				if (s.Contains("="))
				{
					builder.Append(string.Join(".", stack.Reverse().ToArray()));
					builder.Append(" = ");
					builder.Append(s.Last());
					builder.Append(Environment.NewLine);
					stack.Pop();
				}
				if (s.Contains("}"))
				{
					stack.Pop();
				}
			}
			return builder.ToString();
		}
