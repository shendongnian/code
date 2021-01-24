    public class CreateInvoiceViewModel {
        [Required(ErrorMessage = "Company is required")]
        public string Company { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Picture of Invoice Required")]
        public HttpPostedFileBase File { get; set; }
        public int ChurchId { get; set; }
        public IEnumerable<SelectListItem> ChurchList { get; set; }
        //...other properties
    }
    
