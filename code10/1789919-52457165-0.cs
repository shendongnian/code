	var work = new BlockingCollection<Data>();
	
    // instantiate processing task
	var processingTask = Task.Run(() =>
	{
	  foreach (var data in work.GetConsumingEnumerable())
	  {
	  	ProcessData(data);
	  }
	});
	
    // produce data for processing
	for (int i = 0; i < 10; i++)
	{
        var data = LoadFromFile(file);
		work.Add(data); // processing will start as soon as data is added
	}
    // mark that no more data will come, so the processing knows it doesn't need to wait for more work
	work.CompleteAdding();
	
    // await end of processing
	await processingTask;
