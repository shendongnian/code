    public class Book
    {
        public string Name { get; set; }
        public string Likability { get; set; }
    }
    public class SomeBook : Book
    {
        public int NumberOfPages { get; set; }
    }
    public class OtherBook : Book
    {
        public int NumberOfAuthors { get; set; }
    }
