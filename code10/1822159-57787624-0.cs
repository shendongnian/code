var searchClient = new SearchIndexClient(serviceName, indexName, new SearchCredentials(queryApiKey));
var document = searchClient.Documents.Get<YourDocument>(id);
And you need to mark your `Id` with `Key` attribute. This is the minimum required. Please remember about public setters. Otherwise, the document won't deserialize.
public class YourDocument
{
    [System.ComponentModel.DataAnnotations.Key]
    public string Id { get; set; }
}
