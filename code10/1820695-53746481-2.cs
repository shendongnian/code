    namespace MyProject.BusinessModels.Entities
    {
        public class AddressEdit
        {
        [Key]
        public Guid AddressUI { get; set; }
        [Display(Name = "Address")]
        public string Line1 { get; set; }
        [Display(Name = "Address 2")]
        public string Line2 { get; set; }
        [Display(Name = "Country")]
        public int Country { get; set; }
        [Display(Name = "State")]
        public int State { get; set; }
        [Display(Name = "City")]
        public int City { get; set; }
        [Display(Name = "ZipCode")]
        public string ZipCode { get; set; }
        }
    }
