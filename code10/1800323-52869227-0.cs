	[FunctionName("blobtrigger")]
	public static async Task Run(ILogger log, ExecutionContext executionContext,
		[BlobTrigger("blobs/{name}")] Stream blob,
		[Queue("webjobs-blobtrigger-poison")] CloudQueue poisonQueue)
	{
		try {
			// do something
			throw new JsonSerializationException();
		}
		catch (JsonSerializationException ex)
		{
			log.LogError(ex, ex.Message);
			await poisonQueue.AddMessageAsync(new CloudQueueMessage()); // your message
		}
	}
