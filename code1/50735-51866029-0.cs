		public static string CommaQuibbling(IEnumerable<string> items)
		{
			var text = new StringBuilder();
			string sep = null;
			int last_pos = items.Count();
			int next_pos = 1;
			
			foreach(string item in items)
			{
				text.Append($"{sep}{item}");
				sep = ++next_pos < last_pos ? ", " : " and ";
			}
			
			return $"{{{text}}}";
		}
