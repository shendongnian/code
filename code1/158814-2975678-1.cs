    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service : IService
    {
        public string ExecuteRequest(string xmlRequest)
        {
            IRequestManager requestManager = new RequestManager();
            return requestManager.ProcessRequest(xmlRequest);
        }
    }
