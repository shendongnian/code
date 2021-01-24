    public class PaymentDto
    {
    	public PaymentSyncDto PaymentSyncJson { get; set; }
    }
    public class PaymentSyncDto
    {
    	public int Id { get; set; }
    	public string FileName { get; set; }
    	public string Comments { get; set; }
    	public DateTime ProcessingDate { get; set; }
    	public string Status { get; set; }
    	public DateTime CreatedDate { get; set; }
    	public string CreatedBy { get; set; }
    	public DateTime ModifiedDate { get; set; }
    	public string ModifiedBy { get; set; }
    	public int[] PaymentSyncDetails { get; set; }
    }
