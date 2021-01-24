    [DataContract]
    public class Tag
    {
        [DataMember]
        public string Name { get; set; }
    }
    [ServiceContract(CallbackContract = typeof(IAlarmCallback))]
    public interface IAlarmService
    {
        [OperationContract]
        void AlarmInit();
    }
    [ServiceContract]
    public interface IAlarmCallback
    {
        [OperationContract(IsOneWay = true)]
        void RaiseAlarm(Tag tag, double value);
    }
    [ServiceContract(CallbackContract = typeof(IDatabaseCallback))]
    public interface IDatabaseService
    {
        [OperationContract]
        void DatabaseInit();
        [OperationContract]
        void AddSimulationUnit(int address, int signalType, int scanPeriod);
        [OperationContract]
        void RemoveSimulationUnit(int index);
        [OperationContract]
        void AddTag(Tag tag);
        [OperationContract]
        void ModifyTag(string tagId, Tag newTag);
        [OperationContract]
        void RemoveTag(string tagId);
    }
    [ServiceContract]
    public interface IDatabaseCallback
    {
        [OperationContract(IsOneWay = true)]
        void GetTags(List<Tag> tags);
        [OperationContract(IsOneWay = true)]
        void TagAdded(Tag tag);
        [OperationContract(IsOneWay = true)]
        void TagModified(string tagId, Tag newTag);
        [OperationContract(IsOneWay = true)]
        void TagRemoved(string tagId);
    }
    
    [ServiceContract]
    public interface IRTUService
    {
        [OperationContract]
        void RTUInit(string iD, string publicKeyPath);
        [OperationContract]
        void RTUDelete(string iD, byte[] signature);
        [OperationContract]
        void RTScan(int address, double value, string iD, byte[] signature);
    }
    [ServiceContract(CallbackContract = typeof(ITrendingCallback))]
    public interface ITrendingService
    {
        [OperationContract]
        void InitTrending();
    }
    [ServiceContract]
    public interface ITrendingCallback
    {
        [OperationContract(IsOneWay = true,Name = "TrendGetTags")]
        void GetTags(List<Tag> tags);
        [OperationContract(IsOneWay = true, Name = "TrendTagAdd")]
        void TagAdded(Tag tag);
        [OperationContract(IsOneWay = true, Name = "TrendTagModified")]
        void TagModified(string tagId, Tag newTag);
        [OperationContract(IsOneWay = true, Name = "TrendTagRemoved")]
        void TagRemoved(string tagId);
        [OperationContract(IsOneWay = true, Name = "TrendNewScan")] // change the operation name
        void NewScan(string tagId, double value);
    }
