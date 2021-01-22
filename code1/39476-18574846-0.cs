	public static class Helper
	{
		public static string[] HexTbl = Enumerable.Range(0, 256).Select(v => v.ToString("X2")).ToArray();
		public static string ToHex(this IEnumerable<byte> array)
		{
			StringBuilder s = new StringBuilder();
			foreach (var v in array)
				s.Append(HexTbl[v]);
			return s.ToString();
		}
		public static string ToHex(this byte[] array)
		{
			StringBuilder s = new StringBuilder(array.Length*2);
			foreach (var v in array)
				s.Append(HexTbl[v]);
			return s.ToString();
		}
	}
