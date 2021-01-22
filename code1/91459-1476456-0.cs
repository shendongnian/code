    using FluentValidation;
    
    public class CustomerValidator: AbstractValidator<Customer> {
      public CustomerValidator() {
        RuleFor(customer => customer.Surname).NotEmpty();
        RuleFor(customer => customer.Forename).NotEmpty().WithMessage("Please specify a first name");
        RuleFor(customer => customer.Company).NotNull();
        RuleFor(customer => customer.Discount).NotEqual(0).When(customer => customer.HasDiscount);
        RuleFor(customer => customer.Address).Length(20, 250);
        RuleFor(customer => customer.Postcode).Must(BeAValidPostcode).WithMessage("Please specify a valid postcode");
      }
    
      private bool BeAValidPostcode(string postcode) {
        // custom postcode validating logic goes here
      }
    }
    
    Customer customer = new Customer();
    CustomerValidator validator = new CustomerValidator();
    ValidationResult results = validator.Validate(customer);
    
    bool validationSucceeded = results.IsValid;
    IList<ValidationFailure> failures = results.Errors;
