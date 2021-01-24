    [Table("Subjects")]
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200]
        public string Name { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public string Foo { get; set; }
    }
    public class SubjectViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(200, ErrorMessage = "Name MaxLength is 200")]
        public string Name { get; set; }
        [AllowHtml]
        [DataType(DataType.Multiline)]
        public string Description { get; set; }
    }
