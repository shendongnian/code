	classMySyncHandler : IMobileServiceSyncHandler
	{
		MainPage page;
	 
		public MySyncHandler(MainPage page)
		{
			this.page = page;
		}
	 
		publicTask<JObject> ExecuteTableOperationAsync(IMobileServiceTableOperation operation)
		{
			page.AddToDebug("Executing operation '{0}' for table '{1}'", operation.Kind, operation.Table.Name);
			return operation.ExecuteAsync();
		}
	 
		publicTask OnPushCompleteAsync(MobileServicePushCompletionResult result)
		{
			page.AddToDebug("Push result: {0}", result.Status);
			foreach (var error in result.Errors)
			{
				page.AddToDebug("  Push error: {0}", error.Status);
			}
	 
			returnTask.FromResult(0);
		}
	}
