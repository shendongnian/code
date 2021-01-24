        class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, book> books = new Dictionary<int, book>();
            var book1 = new book("Michael", "The Book");
            books.Add(1, book1);
            foreach (KeyValuePair<int, book> b in books)
            {
                Console.WriteLine(b);
            }
        }
    }
    public class book
    {
        private string Author;
        private string Title;
        public book(string Author, string Title)
        {
            this.Author = Author;
            this.Title = Title;
        }
        //Overriding the ToString method.
        override
        public String ToString()
        {
            return Author + " , " + Title;
        }
    }
