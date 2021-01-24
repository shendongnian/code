    public class CreateBookViewModel {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> RelatedBooks { get; set; }
    
        public List<Book> AllBooks { get; set; }
    }
