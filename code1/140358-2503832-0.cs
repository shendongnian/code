    public struct Nullable<T> where T : struct {
        private readonly T value;
        private readonly bool hasValue;
        public Nullable(T value) {
            this.value = value;
            hasValue = true;
        }
        public T Value {
            get {
               if(!hasValue) throw some exception ;-p
               return value;
            }
        }
        public T GetValueOrDefault() { return value; }
        public bool HasValue {get {return hasValue;}}
        public static explicit operator T(Nullable<T> value) {
            return value.Value; }
        public static implicit operator Nullable<T>(T value) {
            return new Nullable<T>(value); }
    }
