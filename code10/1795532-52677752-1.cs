    [DataContract]
    public class OrderStat
    {
        [DataMember]
        public string table_no { get; set; }
        [DataMember]
        public string order_status { get; set; }
    }
    [DataContract]
    public class RootObject
    {
        [DataMember]
        public List<OrderStat> table { get; set; }
    }
