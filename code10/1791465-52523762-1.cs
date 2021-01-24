    public class OrganisationDetailsModel : PageModel
    {
        ...
    
        [BindProperty]
        public InputModel Input { get; set; }
        public void OnGet() { }
    
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
    
            return RedirectToPage("ApplicantDetails");
        }
        public class InputModel
        {
            [BindProperty]
            [RegularExpression(pattern: "(yes|no)")]
            [Required(ErrorMessage = "Please select if you are registered on companies house")]
            public string CompanyHouseToggle { get; set; }
            [BindProperty]
            [StringLength(60, MinimumLength = 3)]
            [RequiredIf("CompanyHouseToggle")]
            public string CompanyNumber { get; set; }
            ...
        }
    }
