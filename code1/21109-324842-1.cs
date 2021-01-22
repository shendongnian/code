    [DataContract]
    public class CreateAccountResponse
    {
        [DataMember]
        public bool CreatedOk { get; set; }
    
        [DataMember]
        public int AccountId { get; set; }
    }
