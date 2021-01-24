    class Account
    {
        public int Status { get; set; }
        public string Msg { get; set; }
        public Dictionary<string, TransactionDetails> transaction_details { get; set; }
    }
    class TransactionDetails
    {
        public string mihpayid { get; set; }
        public string requestid { get; set; }
        public string bank_ref_num { get; set; }
        public string amt { get; set; }
        public string transaction_amount { get; set; }
        public string txnid { get; set; }
        public string additional_charges { get; set; }
        public string Settled_At { get; set; }
    }
