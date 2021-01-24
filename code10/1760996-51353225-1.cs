    public class DBStatus
        {
            [DataMember]
            public DBOperation Type { get; set; }
            [DataMember]
            public List<DBMessageType> Message { get; set; }
            [DataMember]
            public List<string> InnerException { get; set; }
            public DBStatus(){ //initialize here
              Message = new List<DBMessageType>();
              InnerException = new List<string>();
            }
        }
