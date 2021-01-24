    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();
    
        var emptyStudent = new Student();
    
        if (await TryUpdateModelAsync<Student>(
            emptyStudent,
            "student",   // Prefix for form value.
            s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
        {
            _context.Student.Add(emptyStudent);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        return null;
    }
