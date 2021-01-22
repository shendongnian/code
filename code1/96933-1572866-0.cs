		private const int _defaultNumberOfCharacters = 8;
		private const int _defaultExpireDays = 10;
		private static readonly string _allowedCharacters = "bcdfghjklmnpqrstvxz0123456789";
		public static string GenerateKey(int numberOfCharacters)
		{
			const int from = 0;
			int to = _allowedCharacters.Length;
			Random r = new Random();
			StringBuilder qs = new StringBuilder();
			for (int i = 0; i < numberOfCharacters; i++)
			{
				qs.Append(_allowedCharacters.Substring(r.Next(from, to), 1));
			}
			return qs.ToString();
		}
