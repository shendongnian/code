    private static async Task ReadContent(TfvcHttpClient tfvcClient)
    {
    	var changesetId = 123456;
    	var changesetChanges = await tfvcClient.GetChangesetChangesAsync(changesetId);
    	var tfvcVersionDescriptor = new TfvcVersionDescriptor(null, TfvcVersionType.Changeset, changesetId.ToString());
    
    	foreach (var changesetChange in changesetChanges)
    	{
    		var path = changesetChange.Item.Path;
    		Stream contentStream = await tfvcClient.GetItemContentAsync(path, versionDescriptor: tfvcVersionDescriptor);
    		using (StreamReader streamReader = new StreamReader(contentStream))
    		{
    			var content = streamReader.ReadToEnd();
    		}
    	}
    }
