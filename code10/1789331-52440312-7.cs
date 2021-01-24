    public abstract class ModelValidBase {
        protected ValidationContext _validContext;
        protected object parameterValue;
        public ModelValidBase(ValidationContext v, object p)
        {
            _validContext = v;
            parameterValue = p;
        }
        public abstract ValidationResult Dosomthing();
    }
