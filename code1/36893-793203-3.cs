    [XmlRoot("BookList")]
    public class BookList
    {
        [XmlElement("BookData")]
        public List<Book> Books = new List<Book>();
    }
    public class Book
    {
        [XmlElement("Title")]
        public string Title { get; set; }
        [XmlAttribute("isbn")]
        public string ISBN { get; set; }
    }
    var bookList = new BookList
    {
        Books = { new Book { Title = "Once in a lifetime", ISBN = "135468" } }
    };
