    interface IValidationRule {
        bool IsValid { get; }
    }
    class BoxHasText : IValidationRule {
        TextBox _c;
        public BoxHasText(TextBox c) { _c = c; }
        public bool IsValid {
            get { return _c.Text.Length > 0; }
        }
    }
