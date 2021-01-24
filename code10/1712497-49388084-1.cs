	public class IntegerValidationRule : ValidationRule
	{
		public override ValidationResult Validate( object value, CultureInfo cultureInfo )
		{
			var stringData = value as string;
			if( stringData == null )
				return new ValidationResult( false, "not a string" );
			int dummy;
			if( !int.TryParse( stringData, out dummy ) )
				return new ValidationResult( false, "not an integer" );
			return ValidationResult.ValidResult;
		}
	}
