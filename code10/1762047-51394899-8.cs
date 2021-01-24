    public class Layout
    {
        public int Id { get; set; }
        public string Title { get; set; }
 
        [Required]
        public virtual PrintType PrintType { get; set; }
        public Template Template { get; set; }
    }
