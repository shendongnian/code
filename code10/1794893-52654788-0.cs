    public class PropertyValidator : AbstractValidator<Property>
    {
        public PropertyValidator()
        {
            RuleFor(x => x.CorrespondanceAddress)
                .NotNull().WithMessage("Correspondence address cannot be null")
                .SetValidator(new AddressValidator());
            RuleFor(x => x.SecurityAddress)
                .NotNull().WithMessage("Security address cannot be null")
                .SetValidator(new AddressValidator())
                .When(x => !x.CorrespondanceAddressIsSecurityAddress); // applies to all validations chain
              //.Unless(x => x.CorrespondanceAddressIsSecurityAddress); - do the same as at previous line
        }
    }
