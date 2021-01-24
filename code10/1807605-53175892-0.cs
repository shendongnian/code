        public class Term
    {
        [Key]
        public string Id { get; set; }
        public string CleanId { get; set; }
        public DateTime Date { get; set; }
    }
    
    public class App
    {
        public int Id { get; set; }
    
        [ForeignKey("CleanTermId")]
        public Term MyTerm { get; set; }
        public string CleanTermId { get; set; } 
    
    }
    
    public class Question
    {
        public int Id { get; set; }
    
        [ForeignKey("TermId")]
        public Term MyTerm { get; set; }
        public string TermId { get; set; }
    }
