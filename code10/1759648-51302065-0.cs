	// get specific list by name
	ISiteListsCollectionPage list = await graphClient.Sites["root"].Lists.Request()
		.Filter($"DisplayName eq 'YOUR_LIST_NAME_HERE'").GetAsync();
		
	// get columns and output them to the log as a serialized object
	var listColumns = await graphClient.Sites["root"].Lists[list[0].Id].Columns.Request().GetAsync();
	logger.LogInformation($"List Columns Object: {JsonConvert.SerializeObject(listColumns).ToString()}");
