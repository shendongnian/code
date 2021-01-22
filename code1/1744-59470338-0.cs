    public class EnumValidator<TEnum> : AbstractValidator<TEnum> where TEnum : struct, IConvertible, IComparable, IFormattable
    {
        public EnumValidator(string message)
        {
            RuleFor(a => a).Must(a => typeof(TEnum).IsEnum).IsInEnum().WithMessage(message);
        }
    }
