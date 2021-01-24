    public Cliente GetByEmailCpf(string email, string cpf, string colletionId) {
      FeedOptions queryOptions = new FeedOptions {
       MaxItemCount = -1
      };
    
      IQueryable <Cliente> cliente = client.CreateDocumentQuery <Cliente> (
        UriFactory.CreateDocumentCollectionUri(databaseId, colletionId), queryOptions)
       .Where(x => x.Email == email || x.Cpf == cpf).ToList().FirstOrDefault();
    
      return cliente;
     }
