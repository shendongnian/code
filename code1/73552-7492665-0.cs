    public interface IMyService
    {
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        [System.ServiceModel.OperationContract]
        recordResponse GetRecord(recordRequest request);
    }
