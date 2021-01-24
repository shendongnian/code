    public class IndexModel : PageModel {
        private readonly IConnectionOption connectionOption;
    
        public IndexModel(IConnectionOption iConnectionOption) {
            connectionOption = iConnectionOption;
        }
    
        public void OnGet() {
            connectionOption.ReadValue();
            //...
        }
    }
