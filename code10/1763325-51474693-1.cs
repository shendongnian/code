    public HttpResponseMessage GetCollections(int Id)
    {
        List<CollectionDTO> result = _collectionsLogic.GetCollections(Id);
        IContentNegotiator negotiator = this.Configuration.Services.GetContentNegotiator();
        ContentNegotiationResult resultFormatted = negotiator.Negotiate(
                typeof(List<CollectionDTO>), this.Request, this.Configuration.Formatters);
        if (result == null)
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            throw new HttpResponseException(response);
        }
        return new HttpResponseMessage()
        {
            Content = new ObjectContent<List<CollectionDTO>>(
                          result,
                          resultFormatted.Formatter,
                          resultFormatted.MediaType.MediaType
            )};
        }
    }
