				static string Rewrite(string input)
		{
			StringBuilder builder = new StringBuilder();
			var stack = new Stack<string>();
			string[] lines = input.Split('\n');
			foreach (var s in lines)
			{
				if (s.Contains("{"))
				{
					stack.Push(s.Replace("{", String.Empty).Trim());
				}
				if (s.Contains("="))
				{
					var parts = s.Split('=');
					stack.Push(parts[0].Trim());
					builder.Append(string.Join(".", stack.Reverse().ToArray()));
					builder.Append(" = ");
					builder.Append(parts[1].Trim());
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
