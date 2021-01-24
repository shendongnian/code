    public Cliente GetByEmailCpf(string email, string cpf, string colletionId)
    {
        FeedOptions queryOptions = new FeedOptions
        {
            MaxItemCount = -1
        };
    
        var query = client.CreateDocumentQuery<Cliente>(
                  UriFactory.CreateDocumentCollectionUri(databaseId, colletionId), queryOptions)
                 .Where(x => x.Email == email || x.Cpf == cpf);
    
        //If your collection have more than one document of specific email and cpf then
        Cliente cliente = query.ToList().FirstOrDefault();
        //If your collection have only single document of specific email and cpf then
        Cliente cliente = query.ToList().SingleOrDefault();
    
        return cliente;
    }
