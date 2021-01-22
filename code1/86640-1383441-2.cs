    public interface IValidationCRUD
    {
        ICRUDValidation IsValid(object obj);
    }
    
    public abstract class ValidationCRUDBase: IValidationCRUD {
        public abstract ICRUDValidation IsValid(object obj);
        protected abstract void AddError(ICRUDError error);
    }
