	// file 'bootstrapper.cs' in C:\TEMP\CrossPlatformTest
	namespace Cross.Platform.Program
	{
		public static class Bootstrapper
		{
			public static void Main()
			{
				System.AppDomain.CurrentDomain.AssemblyResolve += CustomResolve;
				App.Run();
			}
			private static System.Reflection.Assembly CustomResolve(
				object sender,
				System.ResolveEventArgs args)
			{
				if (args.Name.StartsWith("library"))
				{
					string fileName = System.IO.Path.GetFullPath(
						"platform\\"
						+ System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE")
						+ "\\library.dll");
					System.Console.WriteLine(fileName);
					if (System.IO.File.Exists(fileName))
					{
						return System.Reflection.Assembly.LoadFile(fileName);
					}
				}
				return null;
			}
		}
	}
