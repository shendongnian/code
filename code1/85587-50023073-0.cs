    public cass User
    {
        public string Email { get; set; }
    }
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("The text entered is not a valid email address.");
        }
    }
    // Validates an user. 
    var validationResult = new UserValidator().Validate(new User { Email = "açflkdj" });
    // This will return false, since the user email is not valid.
    bool userIsValid = validationResult.IsValid;
