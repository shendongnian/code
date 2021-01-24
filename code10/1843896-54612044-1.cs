    namespace SMS.Modelz
    {
    public class PlainFormz
    {
        [Required(ErrorMessage = "Please enter Message")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Phone Number 
    without the dashes")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = 
    "Phone Numbers should only contain 10 digits, and should be 
    entered without any dashes.")]
        public string Number { get; set; }
      }
    }
