    [ServiceContract()]
    public interface  IFileUpload
    {
        [OperationContract]
        void Upload(byte[] bys);
    }
