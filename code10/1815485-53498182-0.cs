    [HttpPost]
    public async Task<IActionResult> Search([FromBody]AggregateSearchCriteria criteria)
    {
        return await Common(criteria, c => _searchService.Search(c));
    }
    public async Task<IActionResult> SearchRuleBreak([FromBody]AggregateSearchCriteria criteria)
    {
        return await Common(criteria, c => _searchService.SearchRuleBreak(c));
    }
    private async Task<IActionResult> Common(AggregateSearchCriteria criteria, Func<List<string>, Task<???>> action)
    {
        if (criteria == null || !criteria.Aggregates.Any())
        {
            return BadRequest();
        }
    
        var providers = Request.Headers["providers"];
    
        if (providers.Equals(StringValues.Empty))
            return BadRequest();
    
        criteria.Providers = providers.ToString().Split(',').ToList();
    
        ModelState.Clear();
    
        TryValidateModel(criteria);
    
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
    
        var result = await action.Invoke(criteria);
    
        return Ok(result);
    }
