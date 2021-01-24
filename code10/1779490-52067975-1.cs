        public class CustomerTransaction
    	{
    		public string kwiNumber { get; set; }
    		public string storeNumber { get; set; }
    		public int transactionNumber { get; set; }
    		public DateTime transactionDate { get; set; }
    		public string transactionTime { get; set; }
    		
    		[JsonProperty(PropertyName = "transactionDetails")]
    		public string transactionDetailsRaw { get; set; } 
    		[JsonIgnoreAttribute]
    		public List<TransactionDetail> transactionDetails { get; set; }
    	}
