    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DatePublished { get; set; }
    }
    public class BookViewModel
    {
        public List<Book> Books { get; set; }
    }
