    public class RequestValidator : AbstractValidator<Request>
    {
    	public RequestValidator()
    	{
    		RuleForEach(x => x.Selections).SetValidator(new SelectionValidator());
    	}
    
    	public override ValidationResult Validate(ValidationContext<Request> context)
    	{
    		var result = base.Validate(context);
    		FixIndexedPropertyErrorMessage(result);
    		
    		return result;
    	}
    	public override async Task<ValidationResult> ValidateAsync(ValidationContext<Request> context, CancellationToken cancellation = default(CancellationToken))
    	{
    		var result = await base.ValidateAsync(context, cancellation);
    		FixIndexedPropertyErrorMessage(result);
    
    		return result;
    	}
    
    	private void FixIndexedPropertyErrorMessage(ValidationResult result)
    	{
    		if (result.Errors?.Any() ?? false)
    		{
    			foreach (var error in result.Errors)
    			{
    				// check if the property is an indexer
    				if (Regex.IsMatch(error.PropertyName, @"\[\d+\]") &&
    					error.FormattedMessagePlaceholderValues.TryGetValue("PropertyName", out var propertyName))
    				{
    					// replace PropertyName with its full path
    					error.ErrorMessage = error.ErrorMessage
    						.Replace($"'{propertyName}'", $"'{error.PropertyName}'");
    				}
    			}
    		}
    	}
    }
