    public class ExampleModel : PageModel
    {
        public string ViewComponentName { get; set; }
    
        public async Task<IActionResult> OnGetAsync(string value1, string value2)
        {
            ...
    
            if (value1 == null && value2 == null)
                ViewComponentName = nameof(SomeComponent);
            else
                ViewComponentName = nameof(SomeOtherComponent);
    
            return Page();
        }
    }
