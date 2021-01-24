    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    [MessageContract]
    public class BankingTransaction
    {
       [MessageHeader] public Operation operation;
       [MessageHeader] public DateTime transactionDate;
       [MessageBodyMember] private unit sourceAccount;
       [MessageBodyMember] public int amount;
    }
