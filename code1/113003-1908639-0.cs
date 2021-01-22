    [DataContract]
    [KnownType( typeof( NetworkDeviceProperties ) )]
    public class DeviceProperties
    {
        [DataMember]
        public string MachineName { get; set; }
    }
    [DataContract]
    public class NetworkDeviceProperties : DeviceProperties
    {
        [DataMember]
        public IPAddress IPAddress { get; set; }
    }
    [ServiceContract]
    public interface ICollectionService
    {
        [OperationContract]
        [ServiceKnownType( typeof( NetworkDeviceProperties ) )]
        void Start( DeviceProperties properties );
    }
