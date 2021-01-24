    public interface IValidationRule{
        bool IsValid(object parameter);
    }
    public interface IValidationRule<out T> : IValidationRule
    {
    }
    var foo in container.ResolveAll<IValidationRule>();
