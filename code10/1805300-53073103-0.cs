    public class BriefingTimeRequiredAttribute : ValidationAttribute
    {
    	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    	{
    		var caseInfo = (MyModel)validationContext.ObjectInstance;
    		if (Briefing && !BriefingTime.HasValue)
    		{
    			return new ValidationResult("BriefingTime is required.");
    		}
    		return ValidationResult.Success;
    	}
    }
