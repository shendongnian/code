    [ServiceContract]
    [ServiceKnownType(typeof(PhotoCamera))]
    [ServiceKnownType(typeof(TemperatureSensor))]
    [ServiceKnownType(typeof(DeviceBase))]
    public interface IHomeService
    {
        [OperationContract]
        IDevice GetInterface();
    }
