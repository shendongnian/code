    public static IEnumerable<Document> GetDocuments()
    {
    	var count = 0;
    	while (count++ < 20)
    	{
    		yield return new Document
    		{
    			Id = Guid.NewGuid(),
    			Path = "path",
    			Content = "content" // base64 encoded bytes
    		};
    	}
    }
