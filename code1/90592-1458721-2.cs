	class Program
	{
		static void Main(string[] args)
		{
			RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
			foreach (var v in key.GetSubKeyNames())
			{
				Console.WriteLine(v);
				RegistryKey productKey = key.OpenSubKey(v);
				if (productKey != null)
				{
					foreach (var value in productKey.GetValueNames())
					{
						Console.WriteLine("\tValue:" + value);
						// Check for the publisher to ensure it's our product
						string keyValue = Convert.ToString(productKey.GetValue("Publisher"));
						if (!keyValue.Equals("MyPublisherCompanyName", StringComparison.OrdinalIgnoreCase))
							continue;
						string productName = Convert.ToString(productKey.GetValue("DisplayName"));
						if (!productName.Equals("MyProductName", StringComparison.OrdinalIgnoreCase))
							return;
						string uninstallPath = Convert.ToString(productKey.GetValue("InstallSource"));
						// Do something with this valuable information
					}
				}
			}
			Console.ReadLine();
		}
	}
