    public class MyApplication : IMyApplication {
        #region notifications
       
        public IEmailNotification RequestToFlowEmailNotification { get; set; }
       
        public IEmailNotification ApprovalToFlowEmailNotification { get; set; }
        #endregion
        #region instance providers
       
        public IInstanceProvider DistributionListProvider { get; set; }
       
        public IInstanceProvider AuthorizationToFlowMeterDocumentRecallProvider { get; set; }
        #endregion
    }
    public class RequestToFlowEmailNotification : IEmailNotification {
        #region <Properties>
        
        public IInstanceProvider DistributionListProvider { get; set; }
        #endregion
    }
