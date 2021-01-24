    [System.Runtime.Serialization.DataContract]
    public class ServiceSession
    {         
        [System.Runtime.Serialization.DataMember(Name = "serviceSession")]
        public Dictionary<string, List<ServiceSessionType>> ServiceSessions { get; set; }
    }
