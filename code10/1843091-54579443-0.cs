    public class TenantViewModel
    {
        private Tenant _ten = null;
        [Required]
        public int ItemID { get; set; }
        [Required]
        [MaxLength(30)]
        public string Display_Name { get; set; }
        public string Legal_Name { get; set; }
        ...
    }
