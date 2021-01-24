    public class Book
    {
        public string name { get; set; }
        public int pages { get; set; }
        public string category { get; set; }
        public double rating { get; set; }
        public bool available { get; set; }
    }
    public class BookStore
    {
        public List<Book> Books { get; set; }
    }
