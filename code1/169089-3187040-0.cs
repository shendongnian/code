    [DataContract]
    public class AddressResponse
    {
        [DataMember]
        public Collection<Address> Addresses { get; set; }
    
        [DataMember]
        public string Status { get; set; }
    
    }
