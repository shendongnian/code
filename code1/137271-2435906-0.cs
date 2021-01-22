        [ServiceContract]
        public interface ITestService {
    
            [OperationContract]
            [WebGet(
                BodyStyle = WebMessageBodyStyle.Bare,
                ResponseFormat = WebMessageFormat.Xml            
                )]
            XElement DoWork(string myId);
    
        }
