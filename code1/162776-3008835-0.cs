		private string[] SplitByLength(string s, int d)
		{
			List<string> stringList = new List<string>();
			if (s.Length <= d) stringList.Add(s);
			else
			{
				int x = 0;
				for (; (x + d) < s.Length; x += d)
				{
					stringList.Add(s.Substring(x, d));
				}
				stringList.Add(s.Substring(x));
			}
			return stringList.ToArray();
		}
