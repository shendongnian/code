    public class SsoController: Controller {
        private readonly ICustomerDetails _customerDetails;
        private readonly ISiteSessionProvider siteSessionProvider;
        public SsoController(ICustomerDetails customerDetails, ISiteSessionProvider siteSessionProvider) {
            _customerDetails = customerDetails;
            this.siteSessionProvider = siteSessionProvider;
        }
        public ActionResult CustomerDetails(CustomerDetails customerDetails) {
            //...
            
            ISiteSession siteSession = siteSessionProvider.CreateSiteSession(customerDetails);
            
            //...
        }
    }
    
