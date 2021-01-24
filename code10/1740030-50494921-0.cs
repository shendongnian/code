    // Simple IEnumerable<T> that "uses" an IEnumerator<T> that has
    // already received a MoveNext(). "eats" the first MoveNext() 
    // received, then continues normally. For shortness, both IEnumerable<T>
    // and IEnumerator<T> are implemented by the same class. Note that if a
    // second call to GetEnumerator() is done, the "real" IEnumerator<T> will
    // be returned, not this proxy implementation.
    public class EnumerableFromStartedEnumerator<T> : IEnumerable<T>, IEnumerator<T>
    {
        public readonly IEnumerator<T> Enumerator;
        public readonly IEnumerable<T> Enumerable;
        // Received by creator. Return value of MoveNext() done by caller
        protected bool FirstMoveNextSuccessful { get; set; }
        // The Enumerator can be "used" only once, then a new enumerator
        // can be requested by Enumerable.GetEnumerator() 
        // (default = false)
        protected bool Used { get; set; }
        // The first MoveNext() has been already done (default = false)
        protected bool DoneMoveNext { get; set; }
        public EnumerableFromStartedEnumerator(IEnumerator<T> enumerator, bool firstMoveNextSuccessful, IEnumerable<T> enumerable)
        {
            Enumerator = enumerator;
            FirstMoveNextSuccessful = firstMoveNextSuccessful;
            Enumerable = enumerable;
        }
        public IEnumerator<T> GetEnumerator()
        {
            if (Used)
            {
                return Enumerable.GetEnumerator();
            }
            Used = true;
            return this;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public T Current
        {
            get
            {
                // There are various school of though on what should
                // happens if called before the first MoveNext() or
                // after a MoveNext() returns false. We follow the 
                // "return default(TInner)" school of thought for the
                // before first MoveNext() and the "whatever the 
                // Enumerator wants" for the after a MoveNext() returns
                // false
                if (!DoneMoveNext)
                {
                    return default(T);
                }
                return Enumerator.Current;
            }
        }
        public void Dispose()
        {
            Enumerator.Dispose();
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public bool MoveNext()
        {
            if (!DoneMoveNext)
            {
                DoneMoveNext = true;
                return FirstMoveNextSuccessful;
            }
            return Enumerator.MoveNext();
        }
        public void Reset()
        {
            // This will 99% throw :-) Not our problem.
            Enumerator.Reset();
            // So it is improbable we will arrive here
            DoneMoveNext = true;
        }
    }
