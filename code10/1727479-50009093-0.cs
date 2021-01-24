    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
    
    public class Document
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public Project Project { get; set; }
    }
