    public class BankQueryResponse
    {
        [XmlElement("TRANSACTION_ID")]
        public string TransactionId { get; set; }
    
        [XmlElement("MERCHANT_ACC_NO")]
        public string MerchantAccNo { get; set; }
    
        [XmlElement("TXN_SIGNATURE")]
        public string TxnSignature { get; set; }
    
        [XmlElement("TRAN_DATE")]
        public DateTime TranDate { get; set; }
    
        [XmlElement("TXN_STATUS")]
        public string TxnStatus { get; set; }
    
    
        [XmlElement("REFUND_DATE")]
        public DateTime RefundDate { get; set; }
    
        [XmlElement("RESPONSE_CODE")]
        public string ResponseCode { get; set; }
    
    
        [XmlElement("RESPONSE_DESC")]
        public string ResponseDesc { get; set; }
    
        [XmlAttribute("MERCHANT_TRANID")]
        public string MerchantTranId { get; set; }
    
    }
