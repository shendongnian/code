	using System;
	using System.IO;
	using System.Text;
	class Test
	{
		public static void Main()
		{
			string path = @"c:\1.txt";
			// Open the file to read from.
			using (StreamReader sr = File.OpenText(path))
			{
				string s = sr.ReadLine();
			        
				Console.WriteLine(s);
				Console.ReadLine();
			}
		}
	}
