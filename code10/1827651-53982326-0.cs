    public class UserCredentials
    {
        [Required, EmailAddress, MaxLength(256), Display(Name = "Email Address")]
        public string Email {get;set;}
        
        [Required, MaxLength(20), DataType(DataType.Password), Display(Name ="Password")]
        public string Password {get;set;}
    }
