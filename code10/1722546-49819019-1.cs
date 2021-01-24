    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleSet("Manually", () =>
            {
                RuleFor(x => x.Surname).NotNull();
                RuleFor(x => x.Forename).NotNull();
            });
        }
    }
    public ActionResult ActionWithoutValidationExecuted(Customer customer) 
    {
        //..... Manually binding customer...
        var validator = new CustomerValidator();
        var validResult = validator.Validate(customer, ruleSet: "Manually");
        // Doing something more ........
        return Ok();
    }
