		public static int[] SplitAsIntSafe (this string delimitedString, char splitChar) {
			int			parsed;
			string[]	split	= delimitedString.Split(new char[1] { ',' });
			List<int>	numbers = new List<int>();
			for (var i = 0; i < split.Length; i++) {
				if (int.TryParse(split[i], out parsed))
					numbers.Add(parsed);
			}
			return numbers.ToArray();
		}
