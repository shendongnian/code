    public interface IBook
    {
        string Name { get; set; }
        string Likability { get; set; }
    }
    public class SomeBook : IBook
    {
        public string Name { get; set; }
        public string Likability { get; set; }
        public int NumberOfPages { get; set; }
    }
    public class OtherBook : IBook
    {
        public string Name { get; set; }
        public string Likability { get; set; }
        public int NumberOfAuthors { get; set; }
    }
    public class Books
    {
        public Books()
        {
            IBook[] books = new IBook[2] {
                new SomeBook(),
                new OtherBook()
            };
            for (int i = 0; i < books.Length; i++)
            {
                switch (books[i].GetType().Name)
                {
                    case "SomeBook":
                        int numberOfPages = ((SomeBook)books[i]).NumberOfPages;
                        break;
                    case "OtherBook":
                        int numberOfAuthors = ((OtherBook)books[i]).NumberOfAuthors;
                        break;
                }
            }
        }
    }
