    class AuthInfoValidator : AbstractValidator<AuthInfo>
    {
        public AuthInfoValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage("ConfirmPassword is required");
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithMessage("Passwords must match");
        }
    }
