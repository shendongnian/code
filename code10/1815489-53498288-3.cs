	[HttpPost]
	public async Task<IActionResult> Search([FromBody]AggregateSearchCriteria criteria)
	{
		return await new Search().Apply(criteria);
	}
	[HttpPost("rulebreak")]
	public async Task<IActionResult> SearchRuleBreak([FromBody]AggregateSearchCriteria criteria)
	{
		return await new SearchRuleBreak().Apply(criteria);
	}
