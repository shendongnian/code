    public Enumerator GetEnumerator() => new Enumerator(this);
    // Being a ref struct makes it less likely to mess up the pointer usage,
    // but doesn't affect the foreach loop
    // There is no technical reason why this couldn't implement IEnumerator
    // as long as lifetime issues are considered
    public unsafe ref struct Enumerator
    {
        // Storing the pointer directly instead of the collection reference to reduce indirection
        // Assuming it's immutable for the lifetime of the enumerator
        private readonly T* _ptr;
        private uint _index;
        private readonly uint _endIndex;
        public T Current
        {
            get
            {
                // This check could be omitted at the cost of safety if consumers are
                // expected to never manually use the enumerator in an incorrect order
                if (_index >= _endIndex)
                    ThrowInvalidOp();
                // Without the (int) cast Desktop x86 generates much worse code,
                // but only if _ptr is generic. Not sure why.
                return _ptr[(int)_index];
            }
        }
        internal Enumerator(CustomCollection<T> collection)
        {
            _ptr = collection._ptr;
            _index = UInt32.MaxValue;
            _endIndex = (uint)collection.Length;
        }
        // Technically this could unexpectedly reset the enumerator if someone were to
        // manually call MoveNext() countless times after it returns false for some reason
        public bool MoveNext() => unchecked(++_index) < _endIndex;
        // Pulling this out of the getter improves inlining of Current
        private static void ThrowInvalidOp() => throw new InvalidOperationException();
    }
