    namespace SMS.Models
    {
    public class SomethingElse
    {
        [Required(ErrorMessage = "Please enter the Temporary 
    Password")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = 
    "Password should have at least 8 Characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Phone Number 
    without the dashes")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = 
    "Phone Numbers should only contain 10 digits, and should be 
     entered without any dashes.")]
        public string Number { get; set; }
        }
    }
