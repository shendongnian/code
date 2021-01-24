    public class ApplicationRoleCreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Application Id")]
        public string ApplicationId { get; set; }
    }
