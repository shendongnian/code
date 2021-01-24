    [HttpGet("{id}/{AccountType}")]
    public async Task<OkObjectResult> NewAc(string AccountType)
    {
        var r = await _context.TypeOfAccounts.AnyAsync(o => o.AccountType.ToUpper() == AccountType.ToUpper());
        return Ok(new { r = !r });
    }
