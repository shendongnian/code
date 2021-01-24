    public class SignIn
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class SignUp
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string CellNumber { get; set; }
    }
    public class LandingViewModel
    {
        public SignIn SignIn{ get; set; }
        public SignUp SignUp{ get; set; }
    }
