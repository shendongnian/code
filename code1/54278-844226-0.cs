    [DataContract]
    public class FaultBase {
        [DataMember]
        public string ErrorMessage {get;set;}
    }
    [DataContract]
    public class NotFoundFault : FaultBase {
        [DataMember]
        public int EntityId {get;set;}
    }
    [DataContract]
    public class DuplicateItemFault : FaultBase {
        [DataMember]
        public int EntityId {get;set}
    }
    [DataContract]
    public class InvalidStateFault : FaultBase {
    }
