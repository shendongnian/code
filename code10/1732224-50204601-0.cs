    public class Site
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public ICollection<Link> Links { get; set; }
    }
