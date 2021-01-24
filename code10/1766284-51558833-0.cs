    [Table("Register")]
    public class Register
    {
        [Key]
        public int Sno { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Full name")]
        public string Fullname { get; set; }
        [Display(Name = "Email Id")]
        [Required(ErrorMessage = "Email is required.")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Mobile is required.")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        [Required]
        public string EntityType { get; set; }
        public string Website { get; set; }
        public string PinCode { get; set; }
        public string accountactivated { get; set; }
    }
