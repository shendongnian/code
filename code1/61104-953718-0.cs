		static void Main(string[] args)
		{
			Console.WriteLine("press enter to start");
			Console.ReadLine();
			var path = "c:\\1.rtf";
			for (var i = 0; i < 20; i++)
			{
				using (var stream = new FileStream(path, FileMode.Open))
				{
					var document = new FlowDocument();
					var range = new TextRange(document.ContentStart, document.ContentEnd);
					range.Load(stream, DataFormats.Rtf);
				}
			}
			Console.WriteLine("press enter to run GC.");
			Console.ReadLine();
			GC.Collect();
	        GC.WaitForPendingFinalizers();
			Console.WriteLine("GC has finished .");
			Console.ReadLine();
		}
