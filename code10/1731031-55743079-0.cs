    	public IEnumerable<SelectListItem> CompanyListing { get; private set; }
        public async Task<IActionResult> OnGet()
        {
            if (!string.IsNullOrEmpty(this.ErrorMessage))
            {
                this.ModelState.AddModelError(string.Empty, this.ErrorMessage);
            }
            this.CompanyListing = await this.PopulateCompanyList();
            return this.Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!this.ModelState.IsValid)
            {
                // Something failed. Redisplay the form.
                return await this.OnGet();
            }
            return this.RedirectToPage("/");
        }
