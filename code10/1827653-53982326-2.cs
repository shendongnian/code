    public class User : UserCredentials
    {
        [Required]
        public string FirstName{ get; set; }
        
        [Required]
        public string LastName { get; set; }
    }
