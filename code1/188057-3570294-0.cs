    [DataContract]
    public class Order
    {
       [DataMember]
       public int ID {get; set;}
       [DataMember]
       public string Description {get; set;}
       [DataMember]
       public OrderStatus Status {get; set;}
    }
    
    [DataContract]
    public enum OrderStatus
    {
        [EnumMember]
        New,
        [EnumMember]
        InProcess,
        [EnumMember]   
        Complete
    }
