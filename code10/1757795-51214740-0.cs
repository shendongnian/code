    void Main()
    {
    	var booksList = new List<Book>();
    	booksList.Add(new Book { Name = "book1" });
    	booksList.Add(new Book { Name = "book2" });
    	booksList.Add(new Book { Name = "book1" });
    	booksList.Add(new Book { Name = "book4" });
    	booksList.Add(new Book { Name = "book2" });
    	booksList.Add(new Book { Name = "book4" });
    	booksList.Add(new Book { Name = "book3" });
    	booksList.Add(new Book { Name = "book4" });
    	
    	string BooksName = string.Join(", ", booksList
    		.GroupBy(r =>r.Name)
    		.OrderBy(r => r.First().Name)
    		.Select(s => s.Count() + " X " + s.First().Name));
    
    	Console.WriteLine(BooksName);
    	// Output: 2 X book1, 2 X book2, 1 X book3, 3 X book4
    }
    
    public class Book
    {
    	public int ID { get; set; }
    	public string Name { get; set; }
    	public DateTime date { get; set; }
    }
