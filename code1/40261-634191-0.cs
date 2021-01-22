    [DataContract]
    [KnownType(typeof(Customer))]
    class Contact
    {
       [DataMember]
       public string FirstName
       {get;set;}
    
       [DataMember]
       public string LastName
       {get;set;}
    }
    [DataContract]
    class Customer : Contact
    {
       [DataMember]
       public int OrderNumber
       {get;set;}
    }
