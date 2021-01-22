    using System.ComponentModel.DataAnnotations;
    public class Contact
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "First name must be between 5 and 20 characters")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }
    }
