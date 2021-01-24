    class InternalBaseModelValidator : AbstractValidator<BaseModel>
    {
        public InternalBaseModelValidator()
        {
            RuleFor(x => x.BaseProperty1).NotEmpty().WithMessage("Property 1 is empty");
            RuleFor(x => x.BaseProperty2).NotEmpty().WithMessage("Property 2 is empty");
        }
    }
