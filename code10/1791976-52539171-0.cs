    public class FormValidationModel : PageModel
    {
        [BindProperty, StringLength(5)]
        public string FirstName { get; set; }
    
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("index");
        }
    }
