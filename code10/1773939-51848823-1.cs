    [HttpGet("/api/applications")]
    public async Task<IActionResult> GetApplications()
    {
        var result = await context.Applications.Include(a=> a.AplicantCompany)
                    .Include(c=>c.CreditorCompany)
                    .ToListAsync();
        return Ok(result);
    }
