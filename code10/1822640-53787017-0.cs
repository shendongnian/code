    public class ActionRecordValidator : AbstractValidator<List<Action_Record>>
    {
        public ActionRecordValidator()
        {
            RuleForEach(x => x).Where(x => x.Action == "Approve").SetValidator(new EmailValidator());
        }
    }
    public class EmailValidator : AbstractValidator<Action_Record>
    {
        public EmailValidator()
        {
           RuleFor(x => x.Action_By_Email).NotNull().NotEmpty().WithMessage("Email is required when Approve action is chosen.");
        }
    }
