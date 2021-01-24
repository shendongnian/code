    [HttpPost]
    [ActionName("Add")]
    public async Task<IActionResult> AddAsync([FromBody] MyObject model) {
        var result = await _service.AddAsync(model);
        return result;
    }
