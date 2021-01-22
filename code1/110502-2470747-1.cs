    public class CreateEmployerValidator : AbstractValidator<CreateEmployerModel> {
        public RegisterUserValidator() { 
            RuleFor(m => m.Email)
                .NotEmpty()
                .WithMessage(String.Format(Errors.Required, new object[] { Labels.Email }))
                .EmailAddress()
                .WithMessage(String.Format(Errors.Invalid, new object[] { Labels.Email }))
                .Must(this.BeUniqueEmail)
                .WithMessage(String.Format(Errors.AlreadyRegistered,  new object[] { Labels.Email }));
        }
	
        public bool BeUniqueEmail(this IValidator validator, string email )  {
            //Database request to check if email already there?
            ...
        }	 
    }
