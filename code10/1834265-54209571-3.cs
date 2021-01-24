	public class Foo : ValidationAttribute
	{
		private readonly string _name;
		public Foo(string name)
		{
			_name = name;
		}
		protected override ValidationResult IsValid(object value, ValidationContext context)
		{
			// if the value is null, don't go further
			if (value == null) return ValidationResult.Success;
			// if the value cannot be parsed as a decimal (not valid)
			if (!Decimal.TryParse(value, out decimal d))
			{
				// return an error message
				return new ValidationResult($"{_name} cell should be formatted as...");
			}
			// if the parsed decimal is negative
			if (d < 0)
			{
				// return an error message
				return new ValidationResult($"{_name} cell cannot be negative.");
			}
            
			// if we got this far it was a success
			return ValidationResult.Success;
		}        
	}
