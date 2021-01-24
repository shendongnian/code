    public partial class CUSTOMEREXT
    {
    	[StringLength(36)]
    	public string ID { get; set; }
    
    	[Required]
    	public virtual CUSTOMER CUSTOMER { get; set; }
    }
