	public class ValidFoo : ValidationAttribute
	{
		private readonly string _name;
		public ValidFoo(string name)
		{
			_name = name;
		}
		protected override ValidationResult IsValid(object value, ValidationContext context)
		{
			// if the value is not null or cannot be parsed as a decimal (not valid)
			if (value != null && !Decimal.TryParse(value, out decimal d))
			{
				// return the error message
				return new ValidationResult($"{_name} should be formatted as Currency, etc.");
			}
            
			// if we got this far it was a success
			return ValidationResult.Success;
		}        
	}
