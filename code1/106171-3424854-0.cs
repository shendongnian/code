		public static int[] SplitAsIntSafe (this string csvString, char splitChar) {
			int			parsed;
			string[]	split	= csvString.Split(new char[1] { ',' });
			List<int>	numbers = new List<int>();
			foreach (string n in split) {
				if (int.TryParse(n, out parsed))
					numbers.Add(parsed);
			}
			return numbers.ToArray();
		}
