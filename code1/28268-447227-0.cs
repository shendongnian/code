		public static string[] SplitAndKeepDelimiters(this string Original, string[] Delimeters, StringSplitOptions Options)
		{
			var strings = EnumSplitAndKeepDelimiters(Original, Delimeters);
			
			if (Options == StringSplitOptions.RemoveEmptyEntries)
			{
				return strings.Where((s) => s.Length != 0).ToArray();
			}
			else
			{
				return strings.ToArray();
			}
		}
		
		static IEnumerable<string> EnumSplitAndKeepDelimiters(this string Original, string[] Delimeters)
		{
			int currIndex = 0;
			
			while (currIndex < Original.Length)
			{
				var delimiterIndex = Delimeters.Select((d) => new { Source = d, Index = Original.IndexOf(d, currIndex) })
					.Where((d) => (d.Index != -1) && (d.Source != string.Empty) )
					.OrderBy((d) => d.Index)
					.FirstOrDefault();
            int nextIndex = (delimiterIndex != null ) ? delimiterIndex.Index + delimiterIndex.Source.Length : Original.Length;
				yield return Original.Substring(currIndex, nextIndex - currIndex);
				currIndex = nextIndex;
			}
		}
