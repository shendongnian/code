    class ValidationRule {
        public delegate bool Validator();
        
        private Validator _v;
        public ValidationRule(Validator v) { _v = v; }
        public Validator Validator {
            get { return _v; }
            set { _v = value; }
        }
        public bool IsValid { get { return _v(); } }
    }
    var alwaysPasses = new ValidationRule(() => true);
    var alwaysFails = new ValidationRule(() => false);
    var textBoxHasText = new ValidationRule(() => textBox1.Text.Length > 0);
