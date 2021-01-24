    public class Company
    {
    	[Required]
    	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    	public Guid CompanyId { get; set; }
    
    	[Required]
    	[UniqueKey(groupId: "1", order: 0)]
    	[StringLength(100, MinimumLength = 1)]
    	public string CompanyName { get; set; }
    }
