    public class Department
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Division")]
        public int DivisionId {get; set;}
        [Required]
        [Display(Name = "Department Name")]
        public string Name { get; set; }
        public string Description { get; set; }
    
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        public Division Division { get; set; }
    }
