            [Bind(Exclude = "UserID")]    
            public class UserForAccountEdit
            {
                public User UserAccount { get; set; }
    
                [Required(ErrorMessage = "First name required"), StringLength(20, MinimumLength=3, ErrorMessage = "Must be between 3 and 20 characters")]  
                public string FirstName  
                {  
                  get 
                       { return UserAccount.FirstName };  
                  set
                       { UserAccount.FirstName = value; }
                }  
            
                ...
            }    
    
    
    
            [Bind(Exclude = "UserID")]
            [PropertiesMustMatch("Password", "ConfirmPassword", ErrorMessage = "The password and confirm password don't match.")]
            public class UserForAccountCreation
            {
                public User UserAccount { get; set; }
    
                [Required(ErrorMessage = "First name required"), StringLength(20, MinimumLength=3, ErrorMessage = "Must be between 3 and 20 characters")]  
                public string FirstName  
                {  
                  get 
                       { return UserAccount.FirstName };  
                  set
                       { UserAccount.FirstName = value; }
                }  
            
                ...
            }
