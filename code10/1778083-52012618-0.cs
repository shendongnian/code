    class AddressCreateAPIValidator : AbstractValidator<AddressCreateAPI>
    {
        public AddressCreateAPIValidator()
        {
            RuleFor(d => d.Street)
            .NotEmpty().WithMessage("Address Street is required");
            RuleFor(d => d.City)
                .NotEmpty().WithMessage("Address City is required");
            RuleFor(d => d.StateProvinceId)
                .InclusiveBetween(0, int.MaxValue).WithMessage("Address State is required");
        }
    }
    class SomeClass
    {
        public AddressCreateAPI Prop { get; set; }
    }
    class SomeClassValidator : AbstractValidator<SomeClass>
    {
        public SomeClassValidator()
        {
            RuleFor(d => d.Prop).SetValidator(new AddressCreateAPIValidator());
        }
    }
