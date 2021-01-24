    public partial class ApplicationAnswer
    {
    
        public ApplicationQuestion question { get; set; }
        public ApplicationSubmission submission { get; set; }
    
        public int id { get; set; }
    
        public int application_id { get; set; }
    
        public int question_id { get; set; }
    
        [Column(TypeName = "text")]
        public string answer { get; set; }
    }
