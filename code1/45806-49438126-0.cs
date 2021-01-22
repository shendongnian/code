	class Searcher
	{
		private static object locker = new object(); 
		private FileSearcher searcher;
		List<FileInfo> files;
		public Searcher()
		{
			files = new List<FileInfo>();
		}
		public void Startsearch()
		{
			CancellationTokenSource tokenSource = new CancellationTokenSource();
			searcher = new FileSearcher(@"C:\", (f) =>
			{
				return Regex.IsMatch(f.Name, @".*[Dd]ragon.*.jpg$");
			}, tokenSource);  
			searcher.FilesFound += (sender, arg) => 
			{
				lock (locker) // using a lock is obligatorily
				{
					arg.Files.ForEach((f) =>
					{
						files.Add(f);
						Console.WriteLine($"File location: {f.FullName}, \nCreation.Time: {f.CreationTime}");
					});
					if (files.Count >= 10) 
						searcher.StopSearch();
				}
			};
			searcher.SearchCompleted += (sender, arg) => 
			{
				if (arg.IsCanceled) 
					Console.WriteLine("Search stopped.");
				else
					Console.WriteLine("Search completed.");
				Console.WriteLine($"Quantity of files: {files.Count}"); 
			};
			searcher.StartSearchAsync();
		}
	}
	
