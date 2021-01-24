		static void Main()
		{
			using (StringWriter writer = new StringWriter(), errorWriter = new StringWriter())
			{
				var stdOut = Console.Out;
				var stdErr = Console.Error;
				Console.SetOut(writer);
				Console.SetError(errorWriter);
				try
				{
					MyDllWritesThings();
				}
				finally
				{
					Console.SetOut(stdOut);
					Console.SetError(stdErr);
				}
				Print("StdOut", writer);
				Print("StdErr", errorWriter);
			}
			Console.ReadKey();
		}
		private static void Print(string what, StringWriter writer)
		{
			writer.Flush();
			using (var reader = new StringReader(writer.ToString()))
			{
				var wowInteresting = reader.ReadToEnd();
				Console.WriteLine($"{what}: '{wowInteresting}'");
			}
		}
		private static void MyDllWritesThings()
		{
			Console.WriteLine("Secret output");
			Console.Error.WriteLine("Secret error output");
		}
