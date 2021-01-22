        <button type="submit" name="Submit">Save</button>
        <button type="submit" name="Cancel">Cancel</button>
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();
        var sub = Request.Form["Submit"];
        var can = Request.Form["Cancel"];
        if (sub.Count > 0)
           {
           .......
