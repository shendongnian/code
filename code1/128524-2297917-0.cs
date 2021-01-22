    public class UserCreateViewModel
    {
        [HiddenInput(DisplayValue=false)]
        public string OpenIdClaimedIdentifier { get; set; }
        [HiddenInput(DisplayValue=false)]
        public string OpenIdFriendlyIdentifier { get; set; }
        [Required]
        public string Displayname { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
