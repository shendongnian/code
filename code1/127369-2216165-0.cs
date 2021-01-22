    public class BaseEntity
    {
        public bool IsValid()
        {
            return Validate().IsValid;
        }
    
        public ValidationResults Validate()
        {
            return Validation.Validate(this);
        }
    }
    public class Validation
    {
        public static ValidatorResults Validator<T>( T entity )
            where T : BaseEntity
        {
            return ValidationFactory.CreateValidator(entity.GetType()).Validate(entity);
        }
    }
    
