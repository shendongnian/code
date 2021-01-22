    [PropertiesMustMatch("NewPassword", "ConfirmPassword", ErrorMessage = "The new password and confirmation password do not match.")] 
    public class ChangePasswordModel 
    { 
        public string NewPassword { get; set; } 
        public string ConfirmPassword { get; set; } 
    } 
