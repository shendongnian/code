    	public static double Parse(string str, char decimalSep)
		{
			string s = GetInvariantParseString(str, decimalSep);
			return double.Parse(s, System.Globalization.CultureInfo.InvariantCulture);
		}
		public static bool TryParse(string str, char decimalSep, out double result)
		{
			// NumberStyles.Float | NumberStyles.AllowThousands got from Reflector
			return double.TryParse(GetInvariantParseString(str, decimalSep), NumberStyles.Float | NumberStyles.AllowThousands, System.Globalization.CultureInfo.InvariantCulture, out result);
		}
		private static string GetInvariantParseString(string str, char decimalSep)
		{
			str = str.Replace(" ", "");
			if (decimalSep != '.')
				str = SwapChar(str, decimalSep, '.');
			return str;
		}
		public static string SwapChar(string value, char from, char to)
		{
			if (value == null)
				throw new ArgumentNullException("value");
			StringBuilder builder = new StringBuilder();
			foreach (var item in value)
			{
				char c = item;
				if (c == from)
					c = to;
				else if (c == to)
					c = from;
				builder.Append(c);
			}
			return builder.ToString();
		}
	    private static void ParseTestErr(string p, char p_2)
		{
			double res;
			bool b = TryParse(p, p_2, out res);
			if (b)
				throw new Exception();
		}
		private static void ParseTest(double p, string p_2, char p_3)
		{
			double d = Parse(p_2, p_3);
			if (d != p)
				throw new Exception();
		}
		static void Main(string[] args)
		{
			ParseTest(100100100.100, "100.100.100,100", ',');
			ParseTest(100100100.100, "100,100,100.100", '.');
			ParseTest(100100100100, "100.100.100.100", ',');
			ParseTest(100100100100, "100,100,100,100", '.');
			ParseTestErr("100,100,100,100", ',');
			ParseTestErr("100.100.100.100", '.');
			ParseTest(100100100100, "100 100 100 100.0", '.');
			ParseTest(100100100.100, "100 100 100.100", '.');
			ParseTest(100100100.100, "100 100 100,100", ',');
			ParseTest(100100100100, "100 100 100,100", '.');
			ParseTest(1234567.89, "1.234.567,89", ',');    
			ParseTest(1234567.89, "1 234 567,89", ',');    
			ParseTest(1234567.89, "1 234 567.89",     '.');
			ParseTest(1234567.89, "1,234,567.89",    '.');
			ParseTest(1234567.89, "1234567,89",     ',');
			ParseTest(1234567.89, "1234567.89",  '.');
			ParseTest(123456789, "123456789", '.');
			ParseTest(123456789, "123456789", ',');
			ParseTest(123456789, "123.456.789", ',');
			ParseTest(1234567890, "1.234.567.890", ',');
		}
