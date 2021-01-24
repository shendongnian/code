		static void Main(string[] args)
		{
			WriteDirectories(@"D:\Heaven Benchmark 4.0");
			Console.ReadKey();
		}
		private static void WriteDirectories(string path, int depth = 0)
		{
			string leafName = Path.GetFileName(path);
			string indent = new string(' ', depth * 2);
			Console.WriteLine($"{indent}{leafName}");
			string[] directories = Directory.GetDirectories(path);
			foreach (var directory in directories)
			{
				WriteDirectories(directory, depth + 1);
			}
		}
