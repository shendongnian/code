    namespace Entities
    {
        public class Author
        {
            // this is what a had to add here
            // From here
            public Author()
            {
                Books = new List<Book>();
            }
            // to here
            public int   ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public List<Book> Books { get; set; }
        }
    }
