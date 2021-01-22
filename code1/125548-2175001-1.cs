    public struct Tribool : IEquatable<Tribool> {
        public static Tribool True { get { return new Tribool(true); } }
        public static Tribool False { get { return new Tribool(false); } }
        public static Tribool Unknown { get { return new Tribool(); } }
        enum TriboolState { Unknown = 0, True = 1, False = 2 }
        private readonly TriboolState state;
        public Tribool(bool state) {
            this.state = state ? TriboolState.True : TriboolState.False;
        }
        // default struct ctor handles unknown
        public static bool operator true(Tribool value) {
            return value.state == TriboolState.True;
        }
        public static bool operator false(Tribool value) {
            return value.state == TriboolState.False;
        }
        public static bool operator ==(Tribool x, Tribool y) {
            return x.state == y.state;
        }
        public static bool operator !=(Tribool x, Tribool y) {
            return x.state != y.state; // note: which "unknown" logic do you want?
                                       // i.e. does unknown == unknown?
        }
        public override string ToString() {
            return state.ToString();
        }
        public override bool Equals(object obj) {
            return (obj != null && obj is Tribool) ? Equals((Tribool)obj) : false;
        }
        public bool Equals(Tribool value) {
            return value == this;
        }
        public override int GetHashCode() {
            return state.GetHashCode();
        }
        public static implicit operator Tribool(bool value) {
            return new Tribool(value);
        }
        public static explicit operator bool(Tribool value) {
            switch (value.state) {
                case TriboolState.True: return true;
                case TriboolState.False: return false;
                default: throw new InvalidCastException();
            }
        }
    }
