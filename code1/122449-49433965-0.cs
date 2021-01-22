	class Searcher
	{
		private static object locker = new object(); 
		private FileSearcher searcher;
		List<FileInfo> files;
		public Searcher()
		{
			files = new List<FileInfo>(); // create list that will contain search result
		}
		public void Startsearch()
		{
			CancellationTokenSource tokenSource = new CancellationTokenSource();
			// create tokenSource to get stop search process possibility
			searcher = new FileSearcher(@"C:\", (f) =>
			{
				return Regex.IsMatch(f.Name, @".*[Dd]ragon.*.jpg$");
			}, tokenSource);  // give tokenSource in constructor
			searcher.FilesFound += (sender, arg) => // subscribe on FilesFound event
			{
				lock (locker) // using a lock is obligatorily
				{
					arg.Files.ForEach((f) =>
					{
						files.Add(f); // add the next part of the received files to the results list
						Console.WriteLine($"File location: {f.FullName}, \nCreation.Time: {f.CreationTime}");
					});
					if (files.Count >= 10) // one can choose any stopping condition
						searcher.StopSearch();
				}
			};
			searcher.SearchCompleted += (sender, arg) => // subscribe on SearchCompleted event
			{
				if (arg.IsCanceled) // check whether StopSearch() called
					Console.WriteLine("Search stopped.");
				else
					Console.WriteLine("Search completed.");
				Console.WriteLine($"Quantity of files: {files.Count}"); // show amount of finding files
			};
			searcher.StartSearchAsync();
			// start search process as an asynchronous operation that doesn't block the called thread
		}
	}
	
