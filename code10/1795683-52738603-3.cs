    public class Blog
    {
    	public Guid Id { get; set; }
    	public string Name { get; set; }
    	[Timestamp]
    	public byte[] Timestamp { get; set; }
    }
