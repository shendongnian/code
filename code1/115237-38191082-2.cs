    // 1. remove first char 
		// 2. find permutations of the rest of chars
		// 3. Attach the first char to each of those permutations.
		//     3.1  for each permutation, move firstChar in all indexes to produce even more permutations.
		// 4. Return list of possible permutations.
		public static string[] FindPermutationsSet(string word)
		{
			if (word.Length == 2)
			{
				var c = word.ToCharArray();
				var s = new string(new char[] { c[1], c[0] });
				return new string[]
                {
                    word,
                    s
                };
			}
			var result = new List<string>();
			var subsetPermutations = (string[])FindPermutationsSet(word.Substring(1));
			var firstChar = word[0];
			foreach (var temp in subsetPermutations.Select(s => firstChar.ToString() + s).Where(temp => temp != null).Where(temp => temp != null))
			{
				result.Add(temp);
				var chars = temp.ToCharArray();
				for (var i = 0; i < temp.Length - 1; i++)
				{
					var t = chars[i];
					chars[i] = chars[i + 1];
					chars[i + 1] = t;
					var s2 = new string(chars);
					result.Add(s2);
				}
			}
			return result.ToArray();
		}
