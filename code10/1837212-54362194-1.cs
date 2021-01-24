    [ServiceContract]
    public interface IStore
    {
        [SwaggerWcfPath("Get books", "Retrieve all books from the store")]
        [WebGet(UriTemplate = "/books?filter={filterText}", BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract]
        Book[] ReadBooks(string filterText = null);
    }
