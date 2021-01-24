    class Program
	{
		class StockfishOracle
		{
			private readonly Process process = new Process();
			public StockfishOracle()
			{
				process.StartInfo = new ProcessStartInfo
				{
					FileName = @"D:\stockfish-9-win\Windows\stockfish_9_x64.exe",
					UseShellExecute = false,
					RedirectStandardError = true,
					RedirectStandardInput = true,
					RedirectStandardOutput = true
				};
				process.Start();
				SendUciCommand("uci");
			}
			public IEnumerable<string> GetEvaluation(string fen)
			{
				SendUciCommand($"position fen {fen}");
				SendUciCommand("go depth 1");
				while (!process.StandardOutput.EndOfStream)
				{
					var line = process.StandardOutput.ReadLine();
					yield return line;
					if (line == "uciok")
					{
						break;
					}
				}
			}
			private void SendUciCommand(string command)
			{
				process.StandardInput.WriteLine(command);
				process.StandardInput.Flush();
			}
		}
		static void Main(string[] args)
		{
			var s = new StockfishOracle();
			foreach (var @out in s.GetEvaluation(""))
			{
				Console.WriteLine(@out);
			}
		}
	}
