    namespace ServiceInterface
    {
    
    [ServiceContract]
     public interface IStore
    {
        [SwaggerWcfPath("/books", "Retrieve all books from the store")]
        [WebGet(UriTemplate = "/books?filter={filtername}", BodyStyle = WebMessageBodyStyle.Bare)]
       // [OperationContract]
        Book[] ReadBooks(string filtername=null);
    }
    }
