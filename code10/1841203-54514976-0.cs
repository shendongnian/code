    public class WebService1 : System.Web.Services.Protocols.SoapHttpClientProtocol
    {
        public WebService1()
        {
            this.Url = "http://localhost:61192/WebService1.asmx";
        }
        [WebMethod]
        public string SyncUpdateRecords()
        {
            return "Records updated => sync";
        }
        [WebMethod]
        public IAsyncResult BeginAsyncUpdateRecords(AsyncCallback cb, object state)
        {
            var updateRecords = new UpdateRecords();
            return updateRecords.BeginUpdateRecords(cb, state);
        }
        [WebMethod]
        public string EndAsyncUpdateRecords(IAsyncResult result)
        {
            return UpdateRecords.EndUpdateRecords(result);
        }
    }
