        public class PayInfo
        {
            public Payee Payee { get; set; }
            public Payment Payment { get; set; }
            public List<Remittance> Remittance { get; set; }
        }
        public class Payee
        {
            [JsonProperty("Name")]
            public string PayeeName { get; set; }
            [JsonProperty("Fax")]
            public string PayeeFax { get; set; }
            [JsonProperty("Phone")]
            public string PayeePhone { get; set; }
            public Address Address { get; set; }
            public string Attention { get; set; }
            public string SubmissionDate { get; set; }
            public string PaymentExp { get; set; }
        }
      
        public class Payment
        {
            public string PAN { get; set; }
            public string CVV { get; set; }
            public string Exp { get; set; }
                
        }
        public class Address
        {
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string StateOrProvince { get; set; }
            public string Zip { get; set; }
        }
        public class Remittance
        {
            public string PayorName { get; set; }
            public string PayorId { get; set; }
            public string InvoiceNo { get; set; }
            public string Description { get; set; }
            public string Amount { get; set; }
        }
