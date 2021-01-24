    public abstract class FlagsValueObject<T> : EnumValueObject where T : FlagsValueObject<T> {
        protected readonly IDictionary<int, string> Types = new SortedDictionary<int, string>();
        protected FlagsValueObject(int value, string name) {
            Types[value] = name;
        }
        protected FlagsValueObject() {
        }
        public override string Name {
            get {
                return string.Join(", ", Types.OrderBy(kvp => kvp.Value).Select(kvp => kvp.Value));
            }
        }
        public override int Value {
            get { return Types.Keys.Aggregate((a, b) => a + b); }
        }
        public abstract T And(T other);
        public static T operator |(FlagsValueObject<T> left, T right) {
            return left.And(right);
        }
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
    public abstract class EnumValueObject : IEquatable<EnumValueObject> {
        public abstract string Name { get; }
        public abstract int Value { get; }
        public static bool operator ==(EnumValueObject left, EnumValueObject right) {
            return Equals(left, right);
        }
        public static bool operator !=(EnumValueObject left, EnumValueObject right) {
            return !Equals(left, right);
        }
        public bool Equals(EnumValueObject other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value.Equals(other.Value);
        }
        public override bool Equals(object obj) {
            return obj is EnumValueObject && Equals((EnumValueObject)obj);
        }
        public override int GetHashCode() {
            return string.Join(",", Value, Name).GetHashCode();
        }
        public override string ToString() {
            return Name;
        }
    }
