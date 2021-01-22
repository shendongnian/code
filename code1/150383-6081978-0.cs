    public class SignUpViewModel
    {
        [Required]
        public string Password { get; set; }
    
        [EqualTo("Password", ErrorMessage="Passwords do not match.")]
        public string RetypePassword { get; set; }
    }
