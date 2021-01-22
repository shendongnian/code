    public class Book
    {
        public static IAdapter<Book> Adapter { get; set; }
        public static Book Create(int id)
        {
           return Adapter.Retrieve(id);
        }
        // constructor is internal so that the Adapter can create Book objects
        internal Book() { }
        public int ID { get; internal set; }
        public string Title { get; internal set; }
        public bool AvailableForCheckout { get; internal set; }
    }
