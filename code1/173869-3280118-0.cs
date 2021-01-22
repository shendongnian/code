		private static void ProcessFolder(string folder, string level, string separator, StreamWriter output)
		{
			var dirs = Directory.GetDirectories(folder);
			foreach ( var d in dirs )
			{
				output.Write(level);
				output.WriteLine(d);
				ProcessFolder(d, level + separator, separator, output);
			}
			Console.WriteLine();
			var files = Directory.GetFiles(folder);
			foreach ( var f in files )
			{
				output.Write(level);
				output.WriteLine(f);
			}
		}
