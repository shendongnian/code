    public abstract class FlagsValueObject<T> : EnumValueObject where T : FlagsValueObject<T> {
        protected IDictionary<int, string> Types = new Dictionary<int, string>();
        protected FlagsValueObject(int value, string name) {
            Types[value] = name;
        }
        protected FlagsValueObject() {
        }
        public override string Name {
            get {
                return string.Join(", ", Types.OrderBy(_ => _.Value).Select(_ => _.Value));
            }
        }
        public override int Value {
            get { return Types.Keys.Aggregate((a, b) => a + b); }
        }
        public abstract T And(T other);
        public virtual bool HasFlag(T flag) {
            var typeMatches = GetType().Equals(flag.GetType());
            return typeMatches && (Value & flag.Value) == flag.Value;
        }
        public virtual bool HasFlagValue(int value) {
            return (Value & value) == value;
        }
        public override int GetHashCode() {
            return Types.GetHashCode();
        }
    }
    public abstract class EnumValueObject {
        public abstract string Name { get; }
        public abstract int Value { get; }
        public override bool Equals(object obj) {
            var otherValue = obj as EnumValueObject;
            if (otherValue == null) {
                return false;
            }
            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Value.Equals(otherValue.Value);
            return typeMatches && valueMatches;
        }
        public override int GetHashCode() {
            return string.Join(",", Value, Name).GetHashCode();
        }
        public override string ToString() {
            return Name;
        }
    }
