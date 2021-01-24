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
				process.OutputDataReceived += (sender, args) => this.DataReceived.Invoke(sender, args);
			}
			public event DataReceivedEventHandler DataReceived = (sender, args) => {};
			public void Start()
			{
				process.Start();
				process.BeginOutputReadLine();
			}
			public void Wait(int millisecond)
			{
				this.process.WaitForExit(millisecond);
			}
			public void SendUciCommand(string command)
			{
				process.StandardInput.WriteLine(command);
				process.StandardInput.Flush();
			}
		}
		static void Main()
		{
			var oracle = new StockfishOracle();
			// this will contain all the output of the oracle
			var output = new ObservableCollection<string>();
			// in this way we redirect output from oracle to stdout of the main process
			output.CollectionChanged += (sender, eventArgs) => Console.WriteLine(eventArgs.NewItems[0]);
			// in this way collect all the output from oracle
			oracle.DataReceived += (sender, eventArgs) => output.Add(eventArgs.Data);
			oracle.Start();
			oracle.SendUciCommand("position fen rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
			oracle.SendUciCommand("position startpos moves e2e4");
			oracle.SendUciCommand("go depth 20");
			oracle.Wait(5000); // if output does not contain bestmove after given time, you can wait more
			var bestMove = output.Last();
			Console.WriteLine("Oracle says that the best move is: " + bestMove);
		}
	}
