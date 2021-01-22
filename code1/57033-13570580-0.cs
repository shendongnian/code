    namespace MyApp
    {
        [ServiceContract]
        public interface IMyService
        {
            [WebGet(UriTemplate = "Image.png")]
            [OperationContract]
            Stream ShowImage();
        }
    }
