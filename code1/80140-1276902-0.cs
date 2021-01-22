	class Program
	{
		static void Main(string[] args)
		{
			var process = new Process();
			process.StartInfo = new ProcessStartInfo(@"C:\Windows\System32\cmd.exe", "/c dir");
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.Start();
			var outReader = process.StandardOutput;
			while (!outReader.EndOfStream)
			{
				Console.Write((char)outReader.Read() + ".");
			}
			Console.ReadLine();
		}
	}
