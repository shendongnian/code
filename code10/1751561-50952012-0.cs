    public class FieldValidationException<TModel> : Exception where TModel : class {
        public string FieldName { get; }
    
        public FieldValidationException(string message, Expression<Func<TModel, object>> field) : base(message) {
            FieldName = (MemberExpression)field.Body.Member.Name;
        }
    }
