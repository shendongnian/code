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
    	public List<TransactionDetail> transactionDetails { get; set; }
    }
