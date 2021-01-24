	private async Task SQLBulkLoaderAsync()
	{
		var ab = new ActionBlock<string>(ProcessFileAsync, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 5 });
	
		foreach (var file in indicators.file_list)
		{
			ab.Post(file.series_id);
		}
	
		ab.Complete();
		await ab.Completion;
	}
