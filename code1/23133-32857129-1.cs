      [XmlType("TRANSACTION_RESPONSE")]
    public class TransactionResponse
    {
        [XmlElement("TRANSACTION")]
        public BankQueryResponse Response { get; set; }
    
    }
