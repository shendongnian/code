    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class VendorServer : IVendorServer
    {
        private IMyCallback callback;
        private IVendorService vendorService;
        public VendorServer()
        {
            callback = OperationContext.Current.GetCallbackChannel<IMyCallback>();
            vendorService = new VendorService();
            vendorService.AgentManager.AgentLoggedIn += AgentManager_AgentLoggedIn;
        }
        public void Login(string userName, string password, string stationId)
        {
            vendorService.Login(userName, password, stationId);
        }
        private void AgentManager_AgentLoggedIn(object sender, EventArgs e)
        {
            callback.ReportLoggedIn(...);
        }
    }
