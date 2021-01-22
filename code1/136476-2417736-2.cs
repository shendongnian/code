    public sealed class ToStringBuilder {
        private string _objectName;
        private StringBuilder _innerSb;
        public ToStringBuilder(object obj) {
            _objectName = obj.GetType().Name;
            _innerSb = new StringBuilder();
        }
        public ToStringBuilder Append<T>(string label, T property) {
            if (_innerSb.Length < 1)
                _innerSb.Append(label + ": " + property.ToString());
            else
                _innerSb.Append(", " + label + ": " + property.ToString());
            return this;
        }
        public override string ToString() {
            return _objectName + "{" + _innerSb.ToString() + "}";
        }
    }
