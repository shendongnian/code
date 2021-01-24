    public class Book
    {
        public string name { get; set; }
        public int pages { get; set; }
        public double rating { get; set; }
        public bool available { get; set; }
    }
    public enum BookCategory
    {
        Prism,
        Paragraphia
    }
    public class BookStore
    {
        public Dictionary<BookCategory, List<Book>> Books { get; set; }
    }
