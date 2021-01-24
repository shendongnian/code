    public class User
    {
    	public int Id { get; set; }
	    public int? CreatedById { get; set; }
	    [ForeignKey("CreatedById")]
	    public User CreatedBy { get; set; }
	    public int? UpdatedById { get; set; }
	    [ForeignKey("UpdatedById")]
	    public User UpdatedBy { get; set; }
    }
