   	public static class StringExtensions
	{
		public static string Reverse(this string s)
		{
			var info = new StringInfo(s);
			var charArray = new char[s.Length];
			var teIndices = StringInfo.ParseCombiningCharacters(s).Reverse();
			
			int j = 0;
			foreach(var i in  teIndices)
			{
				if (char.IsHighSurrogate(s[i]))
				{
					charArray[j] = s[i];
					j++;
					charArray[j] = s[i+1];
				}
				else
				{
					charArray[j] = s[i];
				}
				j++;
			}
			
			return new string(charArray);
	
		}
	}
