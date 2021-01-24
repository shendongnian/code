        XmlRoot("RESPONSE", DataType = "PRINT")]
        public class PinDirectResponseVM
        {
            public int TERMINALID { get; set; }
            public string LOCALDATETIME { get; set; }
            public string SERVERDATETIME { get; set; }
            public int TXID { get; set; }
            public string HOSTTXID { get; set; }
            public string AMOUNT { get; set; }
            public string CURRENCY { get; set; }
            public string LIMIT { get; set; }
            
            public ReceiptResponseVM RECEIPT { get; set; }
            public string RESULT { get; set; }
            public string RESULTTEXT { get; set; }
            public string AID { get; set; }
            public PinCredentialsResponseVM PINCREDENTIALS { get; set; }
        }
        public class ReceiptResponseVM //: List<string>
        { 
            [XmlElement(Order = 1, ElementName = "LINES")]
            public int LINES { get; set; }
            [XmlElement(Order = 2, ElementName = "LINE")]
            public List<string> LINE {get; set;}
        }
        public class PinCredentialsResponseVM
        {
            public string PIN { get; set; }
            public string SERIAL { get; set; }
            public string VALIDTO { get; set; }
    
    }
