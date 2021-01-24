    public class Book
    {
        public string Title {get; set;} // Note the {get;set;} here.
        public string Author {get; set;}
        public string ISBN {get; set;}
        public Book(string title, string author, string iSBN)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
        }
    }
