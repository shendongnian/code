    public interface IAnnouncementServiceDuplex
    {
        [OperationContract(IsOneWay = true)]
        void Subscribe(int userId);
    }
    public interface ICalculatorDuplexCallback
    {
        [OperationContract(IsOneWay = true)]
        void SendNotification(AnnouncementData data);
    }
