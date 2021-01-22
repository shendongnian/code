    [ServiceContract]
    [XmlSerializerFormat]
    public class BankingService
    {
    [OperationContract]
        public void ProcessTransaction(BankingTransaction bt)
        {
            // Code not shown.
        }
        
    }
    
    //BankingTransaction is not a data contract class,
    //but is an XmlSerializer-compatible class instead.
    public class BankingTransaction
    {
        [XmlAttribute]
        public string Operation;
        [XmlElement]
        public Account fromAccount;
        [XmlElement]
        public Account toAccount;
        [XmlElement]
        public int amount;
    }
    //Notice that the Account class must also be XmlSerializer-compatible.
