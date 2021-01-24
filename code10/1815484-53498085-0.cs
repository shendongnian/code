    public class AggregateSearchCriteria : IValidatableObject
    {
        [FromHeader]
        public IList<string> Providers { get; set; } = new List<string>();
        public IList<string> Aggregates { get; set; } = new List<string>();
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();
            if (!Providers.Any())
            {
                result.Add(new ValidationResult("No Providers", new[] { nameof(AggregateSearchCriteria.Providers) }));
            }
            if (!Aggregates.Any())
            {
                result.Add(new ValidationResult("No Aggregates", new[] { nameof(AggregateSearchCriteria.Aggregates) }));
            }
            return result;
          }
       }
        [HttpPost]
        public async Task<IActionResult> Search([FromBody]AggregateSearchCriteria criteria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _searchService.Search(criteria);
            return Ok(result);
        }
