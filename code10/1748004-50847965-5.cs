    public class MeasurementContractsApplication : IMeasurementContractsApplication {
        [SetterProperty]
        public IMeasurementContractsUnitOfWork UnitOfWork { get; set; }
    
       
        public IInstanceProvider DistributionListProvider { get; set; }
    
       
        public IInstanceProvider FirstDeliveryNoticeDocumentRecallProvider { get; set; }
    }
