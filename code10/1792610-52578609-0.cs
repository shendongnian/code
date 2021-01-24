	public class CustomTagValidatorAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			Regex re = new Regex(@"(<(?!(LineBreak\s*|Link\s+[\s\w\'\""\=]*)\/?>))", RegexOptions.Multiline);
			return re.Match(value.ToString()).Length == 0 ? ValidationResult.Success : new ValidationResult(Resources.ErrorStrings.InvalidValuesInRequest);
		}
	}
