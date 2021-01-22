    [XmlRoot("BookList")]
    public class BookList
    {
        [XmlElement("BookData")]
        public List<Book> Books = new List<Book>();
        public void Concat(BookList other)
        {
            Books.AddRange(other.Books);
        }
    }
    public class Book
    {
        [XmlElement("Title")]
        public string Title { get; set; }
        [XmlElement("AuthorsText")]
        public string Authors { get; set; }
        [XmlAttribute("isbn")]
        public string ISBN { get; set; }
        [XmlAttribute("isbn13")]
        public string ISBN13 { get; set; }
    }
