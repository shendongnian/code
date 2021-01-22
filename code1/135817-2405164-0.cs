    [DataContract]
    class GetCertMailReceiptNumbersResult
    {
        // no DataMember attribute --> will not be included!
        int AccountNumber {get;set;}
        string Address1 {get;set;}
       ......
        string Password {get;set;}
        // here, include DataMember attributes --> will be included
        [DataMember]
        int ReturnCode {get;set;}
        [DataMember]
        string ReturnMessage {get;set;}
        // and so forth
     }
