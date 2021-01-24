    public class Template
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        [Required]
        public virtual PrintType PrintType { get; set; }
        [Required]
        public Layout Layout { get; set; }
    }
