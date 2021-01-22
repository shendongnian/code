    public class Customer : Entity
    {        
        public IDictionary<string, Book> FavouriteBooks { get; set; }
    }
    public class Book : Entity
    {
        public string Name { get; set; }
    }
