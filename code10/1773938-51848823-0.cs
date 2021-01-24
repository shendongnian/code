    [HttpGet("/api/applications")]
    public async Task<IActionResult> GetApplications()
    {
        var result = await context.Applications.Include(a=> a.AplicantCompany.Name)
                    .Include(c=>c.CreditorCompany.Name)
                    .ToListAsync();
        return Ok(result);
    }
