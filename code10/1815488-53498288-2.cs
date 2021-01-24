	public abstract class BaseSearch
	{
		public Task<IActionResult> Apply(AggregateSearchCriteria criteria)
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
			var result = await ServiceCall(criteria);
			return Ok(result);
		}
		
		protected abstract async IActionResult ServiceCall(AggregateSearchCriteria criteria);
	}
	
	public class Search : BaseSearch
	{
		protected async Task<IActionResult> ServiceCall(AggregateSearchCriteria criteria)
		{
			return await _searchService.Search(criteria);
		}
	}
	
	public class SearchRuleBreak : BaseSearch
	{
		protected async Task<IActionResult> ServiceCall(AggregateSearchCriteria criteria)
		{
			return await _searchService.SearchRuleBreak(criteria);
		}
	}
