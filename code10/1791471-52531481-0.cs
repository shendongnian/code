    public interface IService1
    {
        [OperationContract]
        [WebGet]
        string GetData(int value);
        [OperationContract]
        [WebInvoke(Method = "POST",
       ResponseFormat = WebMessageFormat.Xml,
        RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.WrappedRequest,
       UriTemplate = "BookInfo/")]
        BookingResult Booking(BookInfo bookInfo);
    }
