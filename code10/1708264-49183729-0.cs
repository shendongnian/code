    public abstract class Entity
    {
    	[Key]
    	public int Id { get; set; }
    	[Required]
    	public string Title { get; set; }
    }
