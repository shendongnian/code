	public class Program
	{
		public static string[] tests = new string []
		{
			@"9999 Southgate Dr McKinney,TX 75070",
			@"Glendale Ct Allen, TX 75013",
			@"99999 Balez Drive Frisco, TX 75035",
			@"999 Pine Trail Allen, TX 75002",
			@"999 Richmond Ave Dallas, TX 75206"
		};
		
		public static void Main()
		{
			foreach (var t in tests)
			{
				var a = new Address(t);
				Console.WriteLine("Address: '{0}'  StreetPart: '{1}' CityPart: '{2}'", a, a.StreetPart, a.CityPart);
			}
		}
	}
