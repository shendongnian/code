    public async Task<IActionResult> OnGetAsync(int? id)
    {
        TestData = await _context.TestData.FirstOrDefaultAsync(m => m.TestID == id);
        Input = new InputModel { TestName = TestData.TestName };
        return Page();
    }
