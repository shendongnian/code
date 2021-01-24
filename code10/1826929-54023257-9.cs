    public class Customer
    {
        [Display(Name ="Id")]
        public int Id { get; set; }
        [StringLength(20, MinimumLength = 1)]
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [StringLength(20, MinimumLength = 1)]
        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [EmailAddress]
        [Required]
        [Display(Name ="Email Name")]
        public string Email { get; set; }
    }
