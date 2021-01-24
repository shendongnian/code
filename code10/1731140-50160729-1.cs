	static async void TableStorageController()
	{
		try
		{
			while (true)
			{
				await Task.Delay(TimeSpan.FromMinutes(5), s_cancellationTokenSource.Token);
				foreach (var retaileridkey in s_dictionary.Keys)
				{
					var batchOperation = new TableBatchOperation();
					while (s_dictionary[retaileridkey].Count != 0 && batchOperation.Count < 101)
					{
						batchOperation.InsertOrMerge(s_dictionary[retaileridkey].Take());
					}
					if (batchOperation?.Count != 0)
						await s_azureStorageAccount.VerifyCloudTable.ExecuteBatchAsync(batchOperation);
				}
			}
		}
		catch (Exception ex)
		{
			s_log.Fatal("Azure task run failed", ex);
		}
	}
