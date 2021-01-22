    [ServiceContract]
    public interface IMyServiceContract
    {
        [OperationContract]
        [FaultContract(typeof(NoRoomsAvailableFaultContract))]
        void MyOperation();
    }
