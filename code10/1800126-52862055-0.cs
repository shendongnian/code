    [DataContract]
    class DataItem 
    {
        [DataMember]
        public string Start { get; set; }
    
        [DataMember]
        public string[] Subjects { get; set; } 
    }
    
    [DataContract]
    class ResponseItem
    {
        [DataMember]
        public DateItem[] Data { get; set; }
    }
    
    [DataContract]
    class ResponseContract 
    {
        [DataMember]
        public ResponseItem Response { get; set; }
    }
