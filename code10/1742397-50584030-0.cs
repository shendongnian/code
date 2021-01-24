    public class Doc
    {
        public int Id { get; set; }
    
        public DocType DocType { get; set; }
    
        [Required]
        public int Version { get; set; }
    
        [Required]
        public Byte[] Data { get; set; }
    
        public List<Signature> Signatures { get; set; }
    }
    
    public class Signature {
    
        public int Id { get; set; }
    
        //backwards navigation
        public int DocForeignKey {get;set;}
        [ForeignKey("DocForeignKey")]
        public Doc Doc { get; set; }
    
        public Employee Employee { get; set; }
    
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Signature Date")]
        public DateTime? SignatureDate { get; set; }
    
        public String Value { get; set; }
    }
