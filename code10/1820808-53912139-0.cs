    void Main()
    {
    	
    	var example1 = new SomeType();					// Limit not set, should pass validation
    	var example2 = new SomeType(){Limit = 0};		// Limit set, but illegal value, should fail validation
    	var example3 = new SomeType(){Limit = 10.9m};	// Limit set to legal value, should pass validation
    	
    	var validator = new SomeTypeValidator();
    	
    	Console.WriteLine(validator.Validate(example1).IsValid);	// desired is 'true'
    	Console.WriteLine(validator.Validate(example2).IsValid);	// desired is 'false'
    	Console.WriteLine(validator.Validate(example3).IsValid);	// desired is 'true'
    }
    
    
    public class SomeType
    {
    	public Decimal? Limit { get; set; }
    }
    
    public class SomeTypeValidator : AbstractValidator<SomeType>
    {
    	public SomeTypeValidator()
    	{
    		RuleFor(r=>r.Limit.Value)
    			.NotEmpty()
    			.When(x=> x.Limit.HasValue);
    	}
    }
