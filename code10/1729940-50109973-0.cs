    public class User
    {
        public long Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    // When creating, the client cannot know the Id because it doesn't exist
    public class CreateUserViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    // and when updating, the Id is required but not the Email nor the Password
    public class UpdateUserViewModel
    {
        [Required]
        public long Id { get; set; } 
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
