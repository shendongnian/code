    public class Programs
    {
    	// ...
    	[ForeignKey("Program")]
    	public List<Students> Students { get; set; }
    }
    
    public class Genders
    {
    	// ...
    	[ForeignKey("Gender")]
    	public List<Students> Students { get; set; }
    }
