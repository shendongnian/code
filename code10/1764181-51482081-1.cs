	string[] completionWords = { };
	void SomeRestCall(string search)
	{
		if (editor != null)
		{
			DispatchQueue.GetGlobalQueue(DispatchQueuePriority.Background).DispatchAsync(() =>
			{
				if (string.IsNullOrWhiteSpace(search))
					completionWords = new string[] { };
				else
					// Fake a REST call...
					completionWords = (new string[] { "sushi", "stack", "over", "flow" })
						.Where((word) => word.StartsWith(search, StringComparison.CurrentCulture)).ToArray();
				if (editor != null)
					DispatchQueue.MainQueue.DispatchAsync(() => { editor?.Complete(null); });
			});
		}
	}
