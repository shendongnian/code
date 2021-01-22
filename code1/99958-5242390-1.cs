        [ServiceContract(Namespace = "Application.Service.Contracts")]            
        public interface IVendorService
        {
           [OperationContract]
           [WebInvoke(ResponseFormat=WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
            List<Vendor> RetrieveMultiple(int start, int limit, string sort, string dir);
         }
