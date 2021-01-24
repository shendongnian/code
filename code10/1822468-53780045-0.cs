    public class Book
    { 
    	public int Id { get; set; }
    }
    
    public class Invetory
    {
    	private List<Book> _books = new List<Book>() { new Book() { Id = 1 }, new Book() {Id = 2}};
    
    	public void RemoveBook(int bookId) 
    	{
    		_books.RemoveAll(book => book.Id == bookId);
    	} 
    }
