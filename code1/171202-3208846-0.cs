	void Main()
	{
		
		Console.WriteLine("123\0394".XmlSanitize());
		
	}
	public static class XmlHelpers
	{
		public static string XmlSanitize(this string badString)
		{
			return new String(badString.Where(c => c > 0).ToArray());
		}
	}
