    using System;
	using Newtonsoft.Json;
	using System.Text;
						
	public class Program
	{
		public static void Main()
		{
			var myJSONString = "[{\"FirstName\":\"Bob\",\"LastName\":\"Johnson\"},{\"FirstName\":\"Dan\",\"LastName\":\"Rather\"}]";
			dynamic obj = JsonConvert.DeserializeObject<dynamic>(myJSONString);
			Console.WriteLine(obj[0].FirstName);
		}
	}
