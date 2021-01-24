     // Check if it exists, otherwise delete throws
     var doc = await GetByIdAsync(id, 99); // your method to fetch the document by Id, the partition key (CountryId) is 99 
     if (doc == null)
     {
         return true; // Indicates successful deletion
     }
    
     // Delete
     var uri = UriFactory.CreateDocumentUri("YourCosomosDatabaseId", "Customers", id);
     var reqOptions = new RequestOptions { PartitionKey = new PartitionKey(99) }; // CountryId is 99
     var result = await Client.DeleteDocumentAsync(uri, reqOptions);
     return result.StatusCode == HttpStatusCode.NoContent;
