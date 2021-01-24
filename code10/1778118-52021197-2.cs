    class MyType{
	 [Newtonsoft.Json.JsonProperty(PropertyName="id")]      
	public string Id {get; set;}
    }
    // Get documentUri by:
    UriFactory.CreateDocumentUri(string databaseId, string collectionId, string documentId)
    public Task<ResourceResponse<Document>> ReplaceDocumentAsync(Uri documentUri, object document, RequestOptions options = null);
