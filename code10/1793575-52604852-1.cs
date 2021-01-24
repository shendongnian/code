    public class ApplicationUser : IdentityUser
    {
        [Required]
        public override string UserName { get; set; }
        [Required]
        public override string Email { get; set; }
        [Required]
        public override string PhoneNumber { get; set; }
        public string Address { get; set; }
        [Required]
        public bool IsActive { get;set; }
        [Required]
        public DateTime PwdExpiryDt { get; set; }
        [Required]
        public bool PwdExpiryFlg { get; set; }
        [Required]
        public DateTime LastPwdChgDt { get; set; }
        [Required]
        public DateTime CreatedDt { get; set; }
        [Required]
        public DateTime ModifiedDt { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public string ModifiedBy { get; set; }
    }
