    using System.ComponentModel.DataAnnotations;
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [StringLength(4)]
        public string CreditCardNumberLastFour { get; set; }
        [Required]
        [RegularExpression("", ErrorMessage = "Invalid Email")]
        public string EmailAddress { get; set; }
        public long PhoneNumber { get; set; }
        public bool UserInSession { get; set; }
        public Card Card { get; set; }
    }
