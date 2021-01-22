    private class EmptyEnumerator : IEnumerator
    {
        public EmptyEnumerator()
        {
        }
        #region IEnumerator Members
        public void Reset() { }
        public object Current
        {
            get
            {
                throw new InvalidOperationException();
            }
        }
        public bool MoveNext()
        { return false; }
    }
    public class EmptyEnumerable : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            return new EmptyEnumerator();
        }
    }
