    public class CutomerAuthAttribute : ValidationAttribute
    {
    	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    	{
    		
    		var model = validationContext.ObjectInstance as Result;
    		if (model != null)
    		{
    			string pattern = GetPattern(model);
    
    			if (Regex.IsMatch(value.ToString(), pattern))
    			{
    				return null;
    			}
    		}
    
    		return new ValidationResult("Please input correct float number");
    	}
    
    	private string GetPattern(Result model)
    	{
    		string pattern = "^[+]?[0-9]+";
    
    		if (model.DecimalPlaceRequired > 0)
    			pattern += "[.][0-9]{" + model.DecimalPlaceRequired + "}";
    
    		pattern += "$";
    
    		return pattern;
    	}
    }
