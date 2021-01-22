    class ValidationRule {
        public delegate bool Validator();
        
        private Validator _v;
        public ValidationRule(Validator v) { _v = v; }
        public Validator Validator {
            get { return _v; }
            set { _v = value; }
        }
    }
    var alwaysPasses = new ValidationRule(() => true);
    var alwaysFails = new ValidationRule(() => false);
