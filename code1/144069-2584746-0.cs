		public static IEnumerable<string> InParen(string s)
		{
			int count = 0;
			StringBuilder sb = new StringBuilder();
			foreach (char c in s)
			{
				switch (c)
				{
					case '(':
						count++;
						sb.Append(c);
						break;
					case ')':
						count--;
						sb.Append(c);
						if (count == 0)
						{
							yield return sb.ToString();
							sb = new StringBuilder();
						}
						break;
					default:
						if (count > 0)
							sb.Append(c);
						break;
				}
			}
		}
