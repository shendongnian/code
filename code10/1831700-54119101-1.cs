    public abstract class ValidatorWithFullIndexerPath<T> : AbstractValidator<T>
    {
    	public override ValidationResult Validate(ValidationContext<T> context)
    	{
    		var result = base.Validate(context);
    		FixIndexedPropertyErrorMessage(result);
    
    		return result;
    	}
    	public override async Task<ValidationResult> ValidateAsync(ValidationContext<T> context, CancellationToken cancellation = default(CancellationToken))
    	{
    		var result = await base.ValidateAsync(context, cancellation);
    		FixIndexedPropertyErrorMessage(result);
    
    		return result;
    	}
    
    	protected void FixIndexedPropertyErrorMessage(ValidationResult result)
    	{
    		if (result.Errors?.Any() ?? false)
    		{
    			foreach (var error in result.Errors)
    			{
    				// check if 
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
