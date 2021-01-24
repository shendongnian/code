    [HttpPost]
    [ProducesResponseType(typeof(Dto), 200)]
    public async Task<IActionResult> ParseCsv(IEnumerable<IFormFile> files)
    {
        // Work here...
