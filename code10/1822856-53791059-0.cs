    static void Main(string[] args)
		{
			string query = @"SELECT * FROM Win32_PnPEntity";
			var moSearch = new ManagementObjectSearcher(query);
			var moCollection = moSearch.Get();
			foreach (ManagementObject mo in moCollection)
			{
				Console.WriteLine(mo.Path.ToString());
				foreach (var item in mo.Properties)
				{
					Console.WriteLine($"{item.Name}: {item.Value}");
				}
				Console.WriteLine();
			}
			Console.ReadKey();
		}
