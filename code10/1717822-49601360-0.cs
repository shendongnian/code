    public class UserViewModel {
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 4)]
        public string Password { get; set; }
    }
    
