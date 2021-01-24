	public static class ExtensionMethods
	{
		public static bool FuzzyCompare(this string lhs, string rhs, float ratioRequired)
		{
			var matchingLetters =  lhs.Zip
				( 
					rhs, 
					(a,b) => a == b ? 1 : 0
				)
				.Sum();
			return (float)matchingLetters / (float)lhs.Length > ratioRequired;
		}
	}
