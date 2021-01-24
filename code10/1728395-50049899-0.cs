    public class Book
    {
        public string Title;
        public string Author;
        public string ISBN;
        public Book(string title, string author, string iSBN)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Book);
        }
        protected bool Equals(Book other)
        {
            return string.Equals(ISBN, other?.ISBN);
        }
        public override int GetHashCode()
        {
            return ISBN?.GetHashCode() ?? 0;
        }
    }
