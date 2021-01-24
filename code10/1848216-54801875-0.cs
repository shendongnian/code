     [DataContract]
    public abstract class Parent
    {
       // IsRequired is used to test whether has received the property
     // if not, it will show error. Order could change the order of the property in message 
        [DataMember(IsRequired = true,Order =1)]
        public int Field3 { get; set; }
        [DataMember(IsRequired = true,Order =2)]
        public int Field1 { get; set; }
    }
