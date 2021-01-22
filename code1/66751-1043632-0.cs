    public sealed class ValidationResult<T>
    {
        private readonly bool _valid; // could do an enum {Invalid, Warning, Valid}
        private readonly T _result;
        private readonly List<ValidationMessage> _messages;
        public ValidationResult(T result) { _valid = true; _result = result; _messages = /* empty list */; }
        public static ValidationResult<T> Error(IEnumerable<ValidationMessage> messages)
        {
            _valid = false;
            _result = default(T);
            _messages = messages.ToList();
        }
        public bool IsValid { get { return _valid; } }
        public T Result { get { if(!_valid) throw new InvalidOperationException(); return _result; } }
        public IEnumerable<ValidationMessage> Messages { get { return _messages; } } // or ReadOnlyCollection<ValidationMessage> might be better return type
        // desirable things: implicit conversion from T
        // an overload for the Error factory method that takes params ValidationMessage[]
        // whatever other goodies you want
        // DataContract, Serializable attributes to make this go over the wire
    }
