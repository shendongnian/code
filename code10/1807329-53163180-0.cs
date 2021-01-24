        public class IndexModel : PageModel
        {
            private readonly IConnectionOption _IConnectionOption;
            public IndexModel(IConnectionOption iConnectionOption)
            {
                _IConnectionOption = iConnectionOption;
            }
            public void OnGet()
            {
                _IConnectionOption.ReadValue();
            }
        }
