    public class IndexModel : PageModel
    {
        [ViewData]
        public string Title{ get; set; }
    
        public void OnGet()
        {
            Title = "Index";
        }
    
        // ...
    }
