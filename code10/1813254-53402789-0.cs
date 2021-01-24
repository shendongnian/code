    public class File
    {
    	[Key]
    	public Guid Id { get; set; }
    	[Required]
    	public string Name{ get; set; }
    	[Required]
    	public string Path { get; set; }
    	[Required]
    	public DateTime Registered{ get; set; }
    	[Required]
    	public string RegisteredBy { get; set; }
    	public string Notes { get; set; }
    }
