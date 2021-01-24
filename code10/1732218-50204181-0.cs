    public interface IValidateParameter<in T>
    {
        bool IsValid(T value);
    }
    
