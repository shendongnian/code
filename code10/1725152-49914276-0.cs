    public sealed class WhiteListAttribute : ValidationAttribute
    {
        public static bool EnableWhiteListTags { get; set; }
        private static List<string> whitelistTags = new List<string>() { "strong" };
    	private static Regex regex = new Regex("(</?([^>/]*)/?>)");
    
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string str = (string)value;
    
            if (str != null && 
                ((!EnableWhiteListTags &&
                !RequestValidator.Current.InvokeIsValidRequestString(null, str, RequestValidationSource.Form, null, out int index)) ||
    			(EnableWhiteListTags && !AllTagsValid(str))))
            {
                return new ValidationResult($"A potentially dangerous value was detected from request {validationContext.Name}: {str}");
            }
    
            return ValidationResult.Success;
        }
    	
    	private static bool AllTagsValid(string input)
    	{
    		var matches = regex.Matches(input);
    		var tags = matches.OfType<Match>().Select(m => m.Groups[2].Value);
    		return tags.All(t => whitelistTags.Contains(t.Trim()));
    	}
    }
