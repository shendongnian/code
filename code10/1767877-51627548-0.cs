    [Table("xyz")]
    public partial class TestClass{
        [Key]
        public int key {get; set;}
        [ForeignKey("key")]
        [Required]
        public virtual ExternalClass externalClass{get; set;}
            
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            ... 
        }
    }
