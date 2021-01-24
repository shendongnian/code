    [ServiceContract]
    public interface IErrorService
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetError", BodyStyle = WebMessageBodyStyle.Bare)]
        Stream GetError();
    }
    
    public class ErrorService : IErrorService
    {
        public Stream GetError()
        {
            var result = "Something went wrong...";
            var resultBytes = Encoding.UTF8.GetBytes(result);
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain";
            return new MemoryStream(resultBytes);
        }
    }
