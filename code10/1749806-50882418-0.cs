    public class Author
    {
    	public int Id { get; set; }
    	[Required]
    	public string Name { get; set; }
    	//public virtual List<Book> Books { get; set; }
    }
    
    public class Genre
    {
    	public int Id { get; set; }
    	[Required]
    	public string Name { get; set; }
    	// public virtual List<Book> Books { get; set; }
    }
    
    // This is what you bring back to your View
    public class CombinedViewModel {
    
    	public Genre Genre { get; set; }
    	public Author Author {get; set;}
    }
