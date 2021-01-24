    [HttpGet("accounts", Name ="GetAccounts")]
    public IActionResult GetAll()
    {
        try
        {
            var recordList = _uow.Accounts.GetAll();
            List<DTO.Account> results = new List<DTO.Account>();
            if (recordList != null)
            {
                results = recordList.Select(r => Map(r)).ToList();
            }
            log.Info($"Providers: GetAccounts: Success: {results.Count} records returned");
            return Ok(results);
        }
        catch (Exception ex)
        {
            log.Error($"Providers: GetAccounts: Failed: {ex.Message}");
            return BadRequest($"Providers: GetAccounts: Failed: {ex.Message}");
        }
    }
