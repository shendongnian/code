    public class LoginModel
        {
            [Required(ErrorMessage = "User Name can not be empty!")]
            public string LOGINID { get; set; }
    
            [Required(ErrorMessage = "Password can not be empty!")]
            public string LOGINPW { get; set; }      
    
        }
