    static class ExtensionMethods
    {
		static public IEnumerable<string> GetStuffInsideParentheses(this IEnumerable<char> input)
		{
			int levels = 0;
			var current = new Queue<char>();
			foreach (char c in input)
			{
				if (levels == 0)
				{
					if (c == '(') levels++;
					continue;
				}
				if (c == ')')
				{
					levels--; 
					if (levels == 0)
					{ 
						yield return new string(current.ToArray()); 
						current.Clear();
						continue;
					}
				}
				if (c == '(')
				{
					levels++; 
				}
				current.Enqueue(c); 
			}
		}
    }
