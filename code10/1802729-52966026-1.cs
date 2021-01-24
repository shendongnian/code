    public class SupplierInformationViewModel
    {
        public SupplierInformationViewModel()
        {
            this.CommunicationDetailsViewModel = new List<CommunicationDetailsViewModel>();
        }
    
        [StringLength(50, ErrorMessage = "Organization name cannot be greater than 50 characters"), Required(ErrorMessage ="Organization name is required")]
        public string OrganizationName { get; set; }
    
        public List<CommunicationDetailsViewModel> CommunicationDetailsViewModel { get; set; }
    }
