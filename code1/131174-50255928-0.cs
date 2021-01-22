		static void Main(string[] args)
		{
			var bw = new BackgroundWorker();
			bw.DoWork += Bw_DoWork;
			bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
			bw.RunWorkerAsync();
			Console.ReadKey();
		}
		private static void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			Console.WriteLine("Complete.");
			Console.WriteLine(e.Error);
		}
		private static void Bw_DoWork(object sender, DoWorkEventArgs e)
		{
			throw new NotImplementedException();
		}
