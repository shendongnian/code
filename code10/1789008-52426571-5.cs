    public async Task<Cliente> GetByEmailCpf(string email, string cpf, string colletionId) {
      FeedOptions queryOptions = new FeedOptions {
       MaxItemCount = -1
      };
    
      var query = client.CreateDocumentQuery <Cliente> (
        UriFactory.CreateDocumentCollectionUri(databaseId, colletionId), queryOptions)
       .Where(x => x.Email == email || x.Cpf == cpf).AsDocumentQuery();
      while (query.HasMoreResults)
      {
          var items = await query.ExecuteNextAsync<Cliente>();
          if(items.Count > 0)
              return items.FirstOrDefault();
      }
    
      return null;
     }
