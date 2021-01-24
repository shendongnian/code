    public class CustomValidator : AbstractValidator<Customer> {
      public CustomValidator()
      {
        RuleFor(obj => obj.Prop).NotNull().WithSeverity(Severity.Error);
        RuleFor(obj => obj.Prop).NotEqual("foo").WithSeverity(Severity.Warning);
      }
    }
