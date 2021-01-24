    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string toParse =
    		"[{\r\n    \"kwiNumber\":\"XXXXXXXXXX\",\r\n    \"transactionDetails\" : \"[\\r\\n    {\\\"StoreNumber\\\":\\\"XXXXXX\\\" } \\r\\n]\"}]";
    		List<CustomerTransaction> records = new List<CustomerTransaction>();
    		JArray parsed = JArray.Parse(toParse);
    		foreach(var item in parsed.Children())
    		{
    			CustomerTransaction customerTransaction = JsonConvert.DeserializeObject<CustomerTransaction>(item.ToString());
    			customerTransaction.transactionDetails = JsonConvert.DeserializeObject<List<TransactionDetail>>(customerTransaction.transactionDetailsRaw);
    			records.Add(customerTransaction);
    		}
    	
    	}
    	
    	public class TransactionDetail
    	{
    		public string StoreNumber { get; set; }
    		public string TransactionNumber { get; set; }
    		public string KwiNumber { get; set; }
    		public string TenDigitUPC { get; set; }
    		public string TerminalNumber { get; set; }
    		public string TransactionDate { get; set; }
    		public string TransactionTime { get; set; }
    		public string EmployeeNumber { get; set; }
    		public string CashierNumber { get; set; }
    		public string DiscountReasonCode { get; set; }
    		public string CouponCode { get; set; }
    		public string SalesType { get; set; }
    		public string UnitsSold { get; set; }
    		public string SalePrice { get; set; }
    		public string StyleNumber { get; set; }
    		public string ClassCode { get; set; }
    		public string SubClassCode { get; set; }
    	}
    	
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
    }
