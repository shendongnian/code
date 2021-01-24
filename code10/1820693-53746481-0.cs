        public class EditAddressViewModel
        {
        public Guid AddressUI { get; set; }
        [Display(Name = "Billing Address?")]
        [UIHint("_IsStatus")]
        public bool IsBilling { get; set; }
        [Display(Name = "Shipping Address?")]
        [UIHint("_IsStatus")]
        public bool IsShipping { get; set; }
        [Display(Name = "Location Name")]
        [Required(ErrorMessage = "Location name is required")]
        public string LocationName { get; set; }
        [Display(Name = "Contact Name")]
        [Required(ErrorMessage = "Contact name is required")]
        public string ContactName { get; set; }
        [Display(Name = "Address")]
        public string Line1 { get; set; }
        [Display(Name = "Address 2")]
        [Required(ErrorMessage = "Address line 2 is required - Should be your address or PO Box")]
        public string Line2 { get; set; }
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country name is required")]
        public int Country { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
        [Display(Name = "State")]
        [Required(ErrorMessage = "State name is required")]
        public int State { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
        [Display(Name = "City")]
        [Required(ErrorMessage = "City name is required")]
        public int City { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
        [Display(Name = "ZipCode")]
        public string ZipCode { get; set; }
        [Display(Name = "Contact Email")]
        [Required(ErrorMessage = "Email contact is required")]
        [DataType(DataType.EmailAddress)]
        [StringLength(320)]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Enter a valid email address")]
        public string EmailAddress { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone number is required")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(12)]
        [RegularExpression(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}", ErrorMessage = "Enter a valid phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Fax Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(12)]
        [RegularExpression(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}", ErrorMessage = "Enter a valid phone number")]
        public string FaxNumber { get; set; }
        public int CompanyId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime LastUpdated { get; set; }
    }
