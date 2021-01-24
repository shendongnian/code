		static void Main(string[] args)
		{
			var definition = new { Name = "" };
			string json1 = "{\"Name\":\"Jame's\"}";
			var customer1 = JsonConvert.DeserializeAnonymousType(json1, definition);
			Console.WriteLine(customer1.Name);
		}
