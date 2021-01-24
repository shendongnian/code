    public abstract class FlagsValueObject<T> : EnumValueObject where T : FlagsValueObject<T> {
        protected readonly IDictionary<int, string> Types = new SortedDictionary<int, string>();
        protected FlagsValueObject(int value, string name)
            : base(value, name) {
            Types[value] = name;
        }
        protected FlagsValueObject() {
        }
        public static T operator |(FlagsValueObject<T> left, T right) {
            return left.Or(right);
        }
        protected abstract T Or(T other);
        public virtual bool HasFlag(T flag) {
            return flag != null && (Value & flag.Value) == flag.Value;
        }
        public virtual bool HasFlagValue(int value) {
            return (Value & value) == value;
        }
    }
    public class EnumValueObject : IEquatable<EnumValueObject>, IComparable<EnumValueObject> {
        protected EnumValueObject(int value, string name) {
            Value = value;
            Name = name;
        }
        protected EnumValueObject() {
        }
        public virtual string Name { get; protected set; }
        public virtual int Value { get; protected set; }
        public static bool operator ==(EnumValueObject left, EnumValueObject right) {
            return Equals(left, right);
        }
        public static bool operator !=(EnumValueObject left, EnumValueObject right) {
            return !Equals(left, right);
        }
        public int CompareTo(EnumValueObject other) {
            return Value.CompareTo(other.Value);
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
            return Value.GetHashCode();
        }
        public override string ToString() {
            return Name;
        }
    }
