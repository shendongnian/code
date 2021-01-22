    public Interface IValidationRule {
       bool IsValid(object);
    }
    public class ValidationRule<T> : IValidationRule {
    
        public Func<T, bool> Rule { get; private set; }
        public string ErrorMessage { get; private set; }
    
        public ValidationRule(string errorMessage, Func<object, bool> rule) { 
            Rule = rule;
            ErrorMessage = errorMessage;
        }
    
        public bool IsValid(object obj) {
            return Rule((T)obj);
        }
    }
